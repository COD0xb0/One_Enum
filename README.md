# One_Enum
One_Enum is OneDrive users enumeration tool , that help to detremine valid and unvalid users in your corporation or duraing engegment .
You can check validity for a single user or a list of users.
**FOR LIST OF USERS , THE LIST SHOULD LOOK LIKE THE FOLLOWING:**
0001;0002;N;
Each user should be in a single new line.
=======
**The process of enumeration:**
https://domain-my.sharepoint.com/personal/username_extension/_layouts/15/onedrive.aspx
**Example:**
Domain: testly
Extension: test_ly
username: 1234
https://testly-my.sharepoint.com/personal/1234_test_ly/_layouts/15/onedrive.aspx
**THE CURRENT CODE WORKS VIA EXCEPTION WHICH MEANS WHEN THE TOOL SENDS AN HTTP REQUEST IF THE USER IS VALID IT'LL RETURN 403 CODE AND IF THE USER IS
NOT VALID IT'LL RETURN 404 CODE , AND IN BOTH CASES THE RETURNED RESULT WILL FALL IN THE EXCEPTION , SO THE TOOL MAY TAKE A LONG TIME IF WE TALKING ABOUT
1000 USER AND UP IT'LL TAKE AROUND 4-5MIN**
