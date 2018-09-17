using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadWizard.WinUSBNet;
namespace WINUSB_EchoTest
{
   public partial class Form1 : Form
   {
      public static USBDevice mWinUSBDevice = null;
      public static USBInterface mWinUSBInterface = null;
      public static byte[] readBuffer = new byte[512];
      public static IAsyncResult readResult;
      const string DeviceInterfaceGUID = "{13eb360b-bc1e-46cb-ac8b-ef3da47b4062}";
      public void CreateUSBDevice(String DeviceINterfaceGuid)
      {
         AsyncCallback callBack = new AsyncCallback(ProcessWINUSBData);
         mWinUSBDevice = USBDevice.GetSingleDevice(DeviceINterfaceGuid);
         if (mWinUSBDevice != null)
         {
            mWinUSBInterface = mWinUSBDevice.Interfaces.Find(USBBaseClass.VendorSpecific);
         }
         if (mWinUSBInterface != null)
         {
            if (mWinUSBInterface != null)
            {
               readResult = mWinUSBInterface.InPipe.BeginRead(readBuffer, 0, 512, callBack, this);
            }
         }
      }
      private void ProcessWINUSBData(IAsyncResult result)
      {
         int dataRead = mWinUSBInterface.InPipe.EndRead(result);
         DataReceived(this, readBuffer, dataRead);
         // continue to next read
         AsyncCallback callBack = new AsyncCallback(ProcessWINUSBData);
         readResult = mWinUSBInterface.InPipe.BeginRead(readBuffer, 0, 512, callBack, this);

      }

      public Form1()
      {
         InitializeComponent();
      }
      delegate void AddTextCallback(string text);
      private void AddText(string text)
      {
         // InvokeRequired required compares the thread ID of the

         // calling thread to the thread ID of the creating thread.

         // If these threads are different, it returns true.

         if (this.MsgBox.InvokeRequired)
         {
            AddTextCallback d = new AddTextCallback(AddText);
            this.Invoke(d, new object[] { text });
         }
         else
         {
            this.MsgBox.Items.Add(text);
            MsgBox.TopIndex = MsgBox.Items.Count - 1;
         }
      }
      private void DataReceived(object sender, byte[] dataReceived, int data_length)
      {
         byte[] dataReceived1 = new byte[data_length];
         Array.Copy(dataReceived, dataReceived1, data_length);
         string str;
         if (dataReceived1[0] == '@')
         {
            str = "[R]" + System.Text.Encoding.UTF8.GetString(dataReceived1);
         }
         else
            str =
            "[R]" + BitConverter.ToString(dataReceived1).Replace(',', '-');
         AddText(str);
      }
      private void DataSend(object sender, byte[] dataSent, int data_length)
      {
         string str =
            "[S]" + BitConverter.ToString(dataSent, 0, data_length).Replace(',', '-');
         AddText(str);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         if (mWinUSBDevice == null)
         {
            MessageBox.Show("WINUSB Device not found");
            return;
         }
         List<int> DataList = SendDataTextBox.Text.Split(',').Select(s => Convert.ToInt32(s.Trim(), 16)).ToList();
         UInt16 length = (UInt16)DataList.Count;
         byte[] dataToSend = new byte[length];
         for (int i = 0; i < DataList.Count; i++)
            dataToSend[i] = (byte)DataList[i];
         mWinUSBInterface.OutPipe.Write(dataToSend);
         DataSend(this, dataToSend, length);
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         CreateUSBDevice(DeviceInterfaceGUID);
      }

      private void MsgBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         MsgBox.Items.Clear();
      }
   }
}
