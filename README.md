
# This Is Part Of The BT Wi-Fi Autologin Services Also Available For

 - OpenWRT 
 - Linux
 - Android (& Chromebook)
 
 ### Available Here:
 https://github.com/aidanmacgregor/BTWi-Fi_Autologin_-_OpenWrt_Linux_ChromeOS_Android_Macrodroid_Windows.EXE
 
 # ![Winlogo48NEW](https://user-images.githubusercontent.com/11254983/173395338-8a7c71f5-caf0-45e8-bb6f-0574fd4ec867.png) BT-Wi-Fi-Autologin-Windows 
 
# Features:

 - New UI Design [[NEW v4]]
 - Automatic Login To UK Wide BT Wi-Fi Hotspots
 - Tray Icon Double Click To Restore & Minnimise [[NEW v5]]
 - Tray Icon Will Bring Window To Front Focus [[NEW v5]]
 - Close Will Minimise To Tray (Exit By Using Right Click On Tray Icon, This WONT Run The Log Out URL, If Log Out Is Needed Thet Stop Service First) [[NEW v4]]
 - Tray Icon Changes (Red & Green) To Reflect Current Internet Status Status (Reccomend Dragging Moving It To always Show Next To Wi-Fi Icom) [[NEW v4]]
 - Auto Run Regestery Key & Start Service At Boot Option
 - Saves State & Settings Instsantly When Changing Allowing For Reboot etc... Without loosing Settings [[NEW v4]]
 - Http Response Based Sucsess Check Text Box (Indicates Login Sucsess, No Bt Wi-Fi/Internet, Wrong Username OR Password/Account Type)
 - BT Wi-Fi Map Link Included [[NEW v4]]
 - Status Indicators For Running & Internet
 - Login Count
 - Logoff URL is Run On Stop Service (About 10 Second Delay On BT Side Fr Logout To Stop Internet)
 - HTTP Post Request Used For Login & Logout
 - Complete rewrite, import should work work visual studio [[NEW v4]]
 - Modified Behavour Causing Program Freeze After Waking From Sleep/Hibernate [[NEW v6]]

This is a VB.NET code for a Windows Forms application. It appears to be a tool for managing login sessions to a network service provided by BT (British Telecommunications).

The code includes several declarations of functions from the "user32.dll" library, which are used to control the behavior of the application's window. It also includes a dictionary object that is used to populate a ComboBox with a list of options for the user to choose from.

On the form load event, the code checks the value of an "AutoRun" registry key, which determines whether the application should start automatically when the user logs into their computer. If the key is present, the CheckBoxAutorun checkbox is checked and the application may start automatically.

There is also a ButtonStartStop button that is used to start and stop a background worker process that manages the login sessions. When the button is clicked, the background worker process is started or stopped, and the status of the service is reflected by the color of the ButtonRunningStatus button (green for running and red for stopped).

The code also includes several functions that handle HTTP requests and responses, including login, logout, and checking the status of the login session. These functions use the System.Net.HttpWebRequest and System.Net.HttpWebResponse classes to send and receive HTTP requests and responses.

Finally, the code includes several event handlers that are executed in response to various actions, such as the form being minimized, the user closing the application, or the background worker process completing.

# GUI
![BT Wi-Fi Windows App](https://user-images.githubusercontent.com/11254983/184173045-f6e5ce51-4128-44fb-9964-eadcf718cf71.png)

    
# Windows Downloads
[Login Service](https://github.com/aidanmacgregor/BT-Wi-Fi-Autologin-Windows/releases)
