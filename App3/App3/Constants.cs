using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothBLE
{
    public abstract class Constants
    {
    //HEART RATE SERVICE
    public static String HEART_RATE_SERVICE = "0000180d-0000-1000-8000-00805f9b34fb";
    public static String HEART_RATE_MEASUREMENT = "00002a37-0000-1000-8000-00805f9b34fb";

    //RESPIRATORY RATE SERVICE
    public static  String RESPIRATORY_RATE_SERVICE = "040a1000-6c30-4f6f-8ff8-b4b0822905cb";
    public static  String RESPIRATORY_RATE_MEASUREMENT = "040a1001-6c30-4f6f-8ff8-b4b0822905cb";
    public static  String RESPIRATORY_SIGNAL_MEASUREMENT = "040a1002-6c30-4f6f-8ff8-b4b0822905cb";
    public static  String RESPIRATORY_SIGNAL_SAMPLINGRATE = "040a1003-6c30-4f6f-8ff8-b4b0822905cb";
    public static  String RESPIRATORY_TRIGGER = "040a1004-6c30-4f6f-8ff8-b4b0822905cb";

    //ACTIVITY SERVICE
    public static String ACTIVITY_SERVICE = "040a1010-6c30-4f6f-8ff8-b4b0822905cb";
    public static String ACTIVITY_LEVEL = "040a1011-6c30-4f6f-8ff8-b4b0822905cb";
    public static String PEDOMETER = "040a1012-6c30-4f6f-8ff8-b4b0822905cb";
    public static String FALL_DETECTION = "040a1013-6c30-4f6f-8ff8-b4b0822905cb";

    //ECG SIGNAL SERVICE
    public static String ECG_SIGNAL_SERVICE = "040a1020-6c30-4f6f-8ff8-b4b0822905cb";
    public static String ECG_SIGNAL_MEASUREMENT = "040a1021-6c30-4f6f-8ff8-b4b0822905cb";
    public static String ECG_SIGNAL_SAMPLINGRATE = "040a1022-6c30-4f6f-8ff8-b4b0822905cb";

    //SYNCHRONIZATION SERVICE
    public static String SYNCHRONIZATION_SERVICE = "040a1100-6c30-4f6f-8ff8-b4b0822905cb";
    public static String SYNCHRONIZATION_RECORDS_LIST = "040a1101-6c30-4f6f-8ff8-b4b0822905cb";
    public static String SYNCHRONIZATION_RECORDS_DELETE = "040a1102-6c30-4f6f-8ff8-b4b0822905cb";
    public static String SYNCHRONIZATION_SAVED_RECORD_TRANSMIT = "040a1103-6c30-4f6f-8ff8-b4b0822905cb";
    public static String SYNCHRONIZATION_LIVE_RECORD_TRANSMIT = "040a1104-6c30-4f6f-8ff8-b4b0822905cb";

    //INTERNAL STORAGE INFORMATION SERVICE
    public static String SYNCHRONIZATION_STORAGE_SERVICE = "040a1110-6c30-4f6f-8ff8-b4b0822905cb";
    public static String SYNCHRONIZATION_STORAGE_MAXSIZE = "040a1111-6c30-4f6f-8ff8-b4b0822905cb";
    public static String SYNCHRONIZATION_STORAGE_FREESIZE = "040a1112-6c30-4f6f-8ff8-b4b0822905cb";
    public static String SYNCHRONIZATION_STORAGE_CLEAR = "040a1113-6c30-4f6f-8ff8-b4b0822905cb";

    //CONFIGURAITON SERVICE
    public static String CONFIGURATION_SERVICE = "040a1120-6c30-4f6f-8ff8-b4b0822905cb";
    public static String CONFIGURATION = "040a1121-6c30-4f6f-8ff8-b4b0822905cb";
    public static String DATE_TIME = "00002a08-0000-1000-8000-00805f9b34fb";
    public static String RESETDEVICE = "040a1122-6c30-4f6f-8ff8-b4b0822905cb";

    //DEVICE INFORMATION SERVICE
    public static String DEVICE_INFORMATION_SERVICE = "0000180a-0000-1000-8000-00805f9b34fb";
    public static String MANUFACTURER_NAME_STRING = "00002a29-0000-1000-8000-00805f9b34fb";
    public static String MODEL_NUMBER_STRING = "00002a24-0000-1000-8000-00805f9b34fb";
    public static String HARDWARE_REVISION_STRING = "00002a27-0000-1000-8000-00805f9b34fb";
    public static String FIRMWARE_REVISION_STRING = "00002a26-0000-1000-8000-00805f9b34fb";
    public static String SERIAL_NUMBER_STRING = "00002a25-0000-1000-8000-00805f9b34fb";

    //BATTERY SERVICE
    public static String BATTERY_SERVICE = "0000180f-0000-1000-8000-00805f9b34fb";
    public static String BATTERY_LEVEL = "00002a19-0000-1000-8000-00805f9b34fb";

    }
}
