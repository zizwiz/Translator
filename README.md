# Translator

This app will allow the user to translate text between many different encoding systems. It will also allow the user to contruct Unicode test strings for translation, allow the user to open a file and copy the contents for tanslation. There is also a useful ASCII table.

The app allows right click context menus for Cut, Copy and Paste. Let's look at the App Tab by Tab.

# ASCII <-> Hex.
In this tab we can add Either Hex values in the ASCII range or text in the ASCII range. The ASCII range is all the characters you will find in the ASCII table tab. If the chracters you what to translate are Unicode then use the next tab to translate them.

# Text <-> Unicode <-> UTF8
This tab will allow you to enter in Text, Unicode or UTF8 and translate between them. The text can be RtoL or LtoR.

Note that Unicode is always 2 bytes while UTF8 is either 1, 2 or 3 bytes for each character. 

# ASCII Table
This tab will show the extended ASCII table of 256 characters with a description of each one.

# Unicode Table
We can open any font that is in the collection on the device the program is running on and look at the different Unicode pages. We can open the font in different sizes and Styles. 

If we left click on a cell we will see information about the character
If we right click on the cell its contents will be written into the Text box and it can be then copied to clipboard and translated.
 
# Hex Viewer
This tab will allow you to open a file and view it as a set of Hex Values. This will allow you to take parts of the file and copy them to the clipboard and later paste them into the translator.

# Decimal <-> Hex
In this tab you can convert 32-bit floating-point decimal values into Hexadecimal values. 
It will also allow the conversion of negative numbers into Hexadecimal values.
 
# Round Image Corners
I was looking to round the corners of some PNG files to put them on confluence. I was unable to do this easily in paint and then found some code on how to do a similar thing. I took the code and changed it till it fitted my purpose and worked for me. I think it is self-explanatory what this does. If you save a .png then the transparent corners will be seen but in some other formats this may not be the case so if you save the bitmap and it does not have rounded corners then try saving as .png.
