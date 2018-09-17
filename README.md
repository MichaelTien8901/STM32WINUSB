# STM32WINUSB

This project show the steps to convert STM32 USB CDC to WINUSB Device with HAL library.  This will change the source code of CDC USB HAL library.  "CDC" name will be retained in order to show the differenece.  Also with Microsoft OS String Descriptor, no need to install WINUSB driver for Windows 10.

* Create STM32 USB CDC device using CubeMX.

* Implement echo function

* Change source code of USB library.  Select DeviceInterfaceGUID = {13eb360b-bc1e-46cb-ac8b-ef3da47b4062}
  The DeviceInterfaceGUID is written into both OSStringPropertyDescriptor and INF file.

* Create my_winusb.inf with the DeviceInterfaceGUID as described.  Only Windows 7 and before need 
  install driver.  
