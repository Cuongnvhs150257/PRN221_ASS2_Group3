# PRN221_ASS2_Group3

==========================================================
WPF Application
Assignment 2 (week 4 and 5)
=====================================================================================
Goals:
The goal of Assignment 2 is to develop a WPF Application .NET core named “Music Store” described in document “List of sample projects”.  
System description:
Your system must have the following main functions:
⦁	Buy albums (view albums, add/remove an album to/from cart, and checkout)
⦁	Add/Edit/Delete an album (only for Administrator).

Your program output may be look like:
⦁	Flow of windows









⦁	MainWindow

 
Requirements: 
⦁	Display menus: Shopping, Cart(0), Login, and Album (is enabled when the user is logged in as Administrator)
⦁	Display Class ID and Group number and all members in the status bar (in the bottom of window).
⦁	LoginWindow

 
Requirements:
⦁	Enter user name and password.
⦁	Click  the button “Login” and system will search this member in Database:
⦁	 If it is not found, the following message will be displayed
 

⦁	If that member is found, and his/her role is administrator, the MainWindow form will be displayed as below
 

⦁	ShoppingWindow
 
Requirements: 
⦁	List all albums for the selected genre. Each time only one page (maximum 4 albums) is displayed. Click button ‘Previous’/’Next’ to move to the previous/next page.
⦁	Click button “Add to cart” to add that album to cart, then CartWindow will be displayed.





⦁	CartWindow

 

Requirements: 
⦁	Click the button “Remove from cart” to remove the given album from cart (Count will be decreased by 1 if count > 1, or that album will be remove from cart if Count = 1).
⦁	Click the button “Checkout” (if you are already logged in and total value of Cart is greater than 0) to display “CheckoutWindow”.
⦁	CheckoutWindow 
 
Requirements: 
⦁	Information of user logged in will be filled, and current system date will be considered as order date, the user can enter information as he/she wants.
⦁	Click the button “Save” to save that order into Database, the following message will be displayed
 

⦁	AlbumWindow
 
Requirements: 
⦁	List all albums in the ListView.
⦁	If an album is selected, the information of that album will be displayed in the textboxes.
⦁	Click the button “Delete”, then the following message will be displayed
 
	Then click the button “Yes” to delete that album from Database, and the following message will be displayed
 
⦁	Click the button “Add” to add that album to Database, then the following message will be displayed
 
⦁	Click the button “Update” to update that album in Database, then the following message will be displayed
 

General Requirements:	
⦁	Your system must follow all rules described in Music Store system (in document “List of sample projects”.
⦁	Your system must check input data and allow the user to enter again.
⦁	Use Database “MusicStore” given in site “cms” and must use “localhost” for the name of DB server computer .
⦁	Your solution name: ClassID_GroupN_A2.sln, and file name: ClassID_GroupN_A2.rar
