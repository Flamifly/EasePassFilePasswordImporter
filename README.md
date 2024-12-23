# EasePassFilePasswordImporter
The EasePassFilePasswordImporter is a Plugin, which can be used to Import the following Filetypes:
- CSV
- XML
- JSON
For the Import the Passwords needs to be decrypted. This means it is unsecure because the Passwords will exist without any encryption on the Filesystem.


## CSV Import
The CSV Files can include a Headline with the following Terms:
- UserName
- Password
- Website
- DisplayName
- Notes
- EMail
- TOTPSecret
- TOTPInterval
- TOTPAlgorithm
- TOTPDigits

By specifying a header you can define which data is imported and which line it is in.

For Example:
If you set
***UserName, Password, Website, DisplayName***
as Headline it will only Import those Terms and will only allow the same amount of Terms as Records inside the CSV File

Note:
Following Seperators can be used to seperate the Terms:
- ***\t*** (Tabulator)
- ***,***
- ***;***
- ***:***

You should choose a Seperator, which does not occure in your Terms for example in your Password. If it does occure in your Terms this Record might will not be imported or will imported incorrect!
If you do not want to specify a Headline the default Headline ***DisplayName, UserName, EMail, Password, Website, Notes*** will be used.

Here you can find a [Sample](https://github.com/Flamifly/EasePassFilePasswordImporter/blob/main/Samples/CSVSample.xml)


## XML Import
The XML File should include an Array of PasswordItems.
Here you can find a [Sample](https://github.com/Flamifly/EasePassFilePasswordImporter/blob/main/Samples/XMLSample.xml)


## JSON Import
The JSON File should include an Array of PasswordItems.
Here you can find a [Sample](https://github.com/Flamifly/EasePassFilePasswordImporter/blob/main/Samples/JSONSample.xml)

## PasswordItem
The PasswordItem is a class of the EasePass PasswordManager, which includes the following Properties:
- ***DisplayName***: The Displayname of the Password in EasePass
- ***UserName***: The Username for the Password
- ***EMail***: The E-Mail address of the Password
- ***Website***: The Website where the Password is used
- ***Password***: The Password
- ***Notes***: The Notes for the Password
- ***TOTPSecret***: The Second-Factor Secret
- ***TOTPDigits***: The Second-Factor Digits
- ***TOTPInterval***: The Second-Factor Interval
- ***TOTPAlgorithm***: The Second-Factor Algorithm
The Class will be used for converting the Imported Data to a Format that the EasePass PasswordManager know to be able to handle them.