using System;
using System.Diagnostics;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using BluetoothBLE;
using System.Text;
using System.IO;
using System.Threading.Tasks;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace App3
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public partial class MainPage : Page
    {
        private string ambiotex = "ambiotex";

        private string iPhoneID;
        private ulong deviceAddress;
        private GattDeviceService service;
        StreamSocket stream;
        //ObservableCollection<DeviceInformation> deviceList = new ObservableCollection<DeviceInformation>();
        public DeviceInformation[] deviceList = new DeviceInformation[1];
        private byte[] input;
        public DataReader reader;
        public GattServiceProvider serviceProvider;
        private SensorDataReader sensorData = new SensorDataReader();

        public GattLocalCharacteristicParameters ReadParamater { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();

            //Sets Listener to the Buttons
            bleGetServices.Click += bleGetServices_GetServices;
            StartWatcher();




        }


        //Method is responsible for listening if a bluetoothdevice is in range
        private async void StartWatcher()

        {

            string[] request = { "System.Devices.Aep.DeviceAddress" };

            /*3 Filters(AQS - Advanced Query Syntax) are set:
             * 1. Pairingstate should be false (so only non paired devices discovery);
             * 2. The Device should have a device Adress (no Devices with name "Unknown Device");
             * 3. AEP for better Perfomance on Device
             * 
             */


            DeviceWatcher watcher = DeviceInformation.CreateWatcher(
                 //BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                 BluetoothLEDevice.GetDeviceSelectorFromDeviceName("ambiotex"),
                request,
                DeviceInformationKind.AssociationEndpoint);

            //what happens if a device is recognized or not
            watcher.Added += DeviceWatcher_Added;
            watcher.Removed += DeviceWatcher_Removed;


            watcher.Start();

           
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

            base.OnNavigatedFrom(e);
        }

        private void disConnectBtn_Disconnect(object sender, RoutedEventArgs e)
        {
            //if Disconnect Button is pressed..
            //consoleList.Items.Add("Die Verbindung mit : " + '"' + ambiotex + '"' + " wurde beendet...");
            disconnectHandler(service);
        }

        private async void bleGetServices_GetServices(object sender, RoutedEventArgs e)
        {
            //if Connect Button is pressed..
            //get Instance of BluetoothDevice 

            var device = await BluetoothLEDevice.FromBluetoothAddressAsync(deviceAddress);

            //get UUID of Services
            var services = await device.GetGattServicesAsync();
            if (services != null)
            {
                foreach (var servicesID in services.Services)
                {
                    updateServiceList($"Service: {servicesID.Uuid}");
                    var characteristics = await servicesID.GetCharacteristicsAsync();
                    foreach (var character in characteristics.Characteristics)
                    {
                        await sensorData.readData(servicesID, character);
                        serviceChecked(sensorData.check);




                    }
                }
            }
        }

        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {          
            deviceAddress = 31587540480693;
            iPhoneID = args.Id;
            deviceList[0] = args;

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
               () =>
                {

                    bleList.Items.Add(args.Name);
                    return;

                
                });
        }

        private async void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            string deviceId = deviceList[0].Id;
            if (deviceId == args.Id) { }
            //throw new NotImplementedException();
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
               () =>
               {

                   
                   bleList_delete(deviceList[0].Name);

               });

        }

        private async void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {

        }


        private void bleList_delete(string device)
        {
            bleList.Items.Remove(device);
        }

        //updates the Service List ("Services Field in XAML")
        public void updateServiceList(string update)
        {
            serviceList.Items.Add(update);
        }

        public  void serviceChecked(string check)
        {
            if(check == "battery")
            {
                checkBoxBattery.Fill = new SolidColorBrush(Windows.UI.Colors.Green);

            }
            if (check == "heart")
            {
                checkBoxHeart.Fill = new SolidColorBrush(Windows.UI.Colors.Green);

            }
            if (check == "pedometer")
            {
                checkBoxPedometer.Fill = new SolidColorBrush(Windows.UI.Colors.Green);

            }
        }

        private async void disconnectHandler(GattDeviceService service)
        {
            stream = new StreamSocket();
            await stream.CancelIOAsync();
        }

    }

}
