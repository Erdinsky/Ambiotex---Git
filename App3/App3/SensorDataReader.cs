using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
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
using System.Threading.Tasks;
using System.Text;

namespace BluetoothBLE

{
    public class SensorDataReader
    {
        public string check;
        public string inputFromReader;
        private byte[] inputBattery;
        private byte[] inputPedometer;
        private byte[] inputHeart;
        public DataReader readerBattery;
        public DataReader readerPedometer;
        public DataReader readerHeart;

        public string heartRateData;
        public string batteryLevelData;
        public async Task<String> readData(GattDeviceService service, GattCharacteristic character)

        {

            //HANDLE BATTERY STATUS
            if (service.Uuid.ToString() == Constants.BATTERY_SERVICE && character.Uuid.ToString() == Constants.BATTERY_LEVEL )
            {
                
                getBatteryData(character);
                check = "battery";


            }
            //HANDLE ECG STATUS
            if(service.Uuid.ToString() == Constants.ECG_SIGNAL_SERVICE ){
                if(character.Uuid.ToString() == Constants.ECG_SIGNAL_MEASUREMENT)
                {

                }
                else if(character.Uuid.ToString() == Constants.ECG_SIGNAL_SAMPLINGRATE)
                {

                }
           
            }
            //HANDLE PEDOMETER
            if(service.Uuid.ToString() == Constants.ACTIVITY_SERVICE)
            {
                if (character.Uuid.ToString() == Constants.ACTIVITY_LEVEL)
                {

                }
                else if (character.Uuid.ToString() == Constants.PEDOMETER) 
                {
                   check = "pedometer";
            //       return await getPedometerData(character);
                }
            }
            //HANDLE HEART RATE
            if (service.Uuid.ToString() == Constants.HEART_RATE_SERVICE && character.Uuid.ToString() == Constants.HEART_RATE_MEASUREMENT)
            {
                check = "heart";
                getHeartData(character);
                // String timeStamp = GetTimestamp(DateTime.Now);
                
            }
            {
                
                
            }


       




            return "";
            
            
        }

        public async void getBatteryData(GattCharacteristic character)
        {
            GattReadResult result = await character.ReadValueAsync();
            if (character.Uuid.ToString() == Constants.BATTERY_LEVEL)
            {
                readerBattery = DataReader.FromBuffer(result.Value);
                inputBattery = new byte[readerBattery.UnconsumedBufferLength];
                readerBattery.ReadBytes(inputBattery);
                GattCommunicationStatus status = await character.WriteClientCharacteristicConfigurationDescriptorAsync(
                GattClientCharacteristicConfigurationDescriptorValue.Notify);
                // character.ValueChanged += Character_BatteryValueChanged;
                if (status == GattCommunicationStatus.Success)
                {

                }
                
            }
            
            batteryLevelData =  BitConverter.ToString(inputBattery);
            Debug.WriteLine("BATTERY LEVEL  " + batteryLevelData);
        }

        public async void getHeartData(GattCharacteristic character)
        {
            GattCommunicationStatus status = await character.WriteClientCharacteristicConfigurationDescriptorAsync(
            GattClientCharacteristicConfigurationDescriptorValue.Notify);
            
        
            if (status == GattCommunicationStatus.Success)
            {
                character.ValueChanged += Character_HeartValueChanged;
            }


            

        }
        public async Task<String> getPedometerData(GattCharacteristic character)
        {
            GattReadResult result = await character.ReadValueAsync();
            if (character.Uuid.ToString() == Constants.PEDOMETER)
            {
                readerPedometer = DataReader.FromBuffer(result.Value);
                inputPedometer = new byte[readerPedometer.UnconsumedBufferLength];
                readerPedometer.ReadBytes(inputPedometer);
                GattCommunicationStatus status = await character.WriteClientCharacteristicConfigurationDescriptorAsync(
                GattClientCharacteristicConfigurationDescriptorValue.Notify);
                // character.ValueChanged += Character_BatteryValueChanged;
                if (status == GattCommunicationStatus.Success)
                {

                }

            }

            return BitConverter.ToString(inputPedometer);

        }

        private async void Character_BatteryValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            /*
            reader = DataReader.FromBuffer(args.CharacteristicValue);
            input = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(input);
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
               () =>
               {
                   //updateServiceList("Updated Akku: " + BitConverter.ToString(input));
               });
*/
        }

        private async void Character_HeartValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            readerHeart = DataReader.FromBuffer(args.CharacteristicValue);
            inputHeart = new byte[readerHeart.UnconsumedBufferLength];
            readerHeart.ReadBytes(inputHeart);

            string data = BitConverter.ToString(inputHeart);
            heartRateData = data.Substring(3, 2);
            Debug.WriteLine("HEART RATE:   "+ heartRateData);
           
        }

        public static String GetTimestamp(DateTime value)
        {
           
            return value.ToString("yyyyMMddHHmmssffff");
        }

    }
}
