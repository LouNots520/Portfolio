import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.Scanner;
import java.io.ObjectOutputStream;
import java.io.ObjectInputStream;

public class Admin 
{
	private File file;
	private Scanner sc;			// Keyboard Scanner
	private User activeUser;
	private User tempUser;
	private ArrayList<User> UserList = new ArrayList<User>();
	private static String menu = " 1. New User\n 2. Log in\n" +
			" 3. Change Password\n 4. Log off\n 5. List users\n 6. Quit\n";
	private Integer UID;
	private Integer activeUID;
	private ObjectOutputStream oos;
	private ObjectInputStream ois;
	private FileInputStream fis;
	private FileOutputStream fos;
	
	// Creating Admin Constructor.
	Admin() throws IOException, ClassNotFoundException, NoSuchAlgorithmException
	{
		Logout();
		ReadUser();
	}
	
	void ReadUser() throws IOException, ClassNotFoundException, FileNotFoundException, NoSuchAlgorithmException
	{
		file = new File("userFile.txt");
		try
		{
			// Read in users.
			readObject();
			System.out.println("Found");
		}
		catch(FileNotFoundException ex)
		{
			System.out.println("File Not Found!");
		}
		try
		{
			// Creating a new file.
			file.createNewFile();
		}
		catch(IOException ex)
		{
			System.out.println("Can't Create File!");
		}
	}
	// End ReadUser() 
	
	void doMenu() throws IOException, NoSuchAlgorithmException
	{
		sc = new Scanner(System.in);
		try
		{
			for(;;)
			{
				System.out.print(menu);
				// Reading input as string then converting to integer.
				int choice = Integer.parseInt(sc.nextLine());
				// Invalid menu option.
				while(choice < 1 || choice > 6)
				{
					System.out.printf("\n%s is an Invalid menu choice!\n", choice);
					System.out.printf(menu);
					choice = Integer.parseInt(sc.nextLine());
				}
				// Menu options
				switch(choice)
				{
				case 1 : newUser(); break;
				case 2 : Login(); break;
				case 3 : changePassword(); break;
				case 4 : Logout(); break;
				case 5 : displayUsers(); break;
				}
				// Quit option.
				if(choice == 6)
				{
					sc.close();
					break;
				}
			}
		}
		finally
		{
			// Writing ArrayList to file.
			writeObject();
		}
	}
	// End doMenu
	
	void newUser() throws NoSuchAlgorithmException
	{
		// Getting information about user.
		System.out.println("Enter the User Full Name:");
		String fname = sc.nextLine();
		System.out.println("Enter the User Name:");
		String uname = sc.nextLine();
		String password = getPassword();
		// Creating a user.
		tempUser = new User(fname, uname, password);
		// Adding user to ArrayList
		UserList.add(tempUser);
	}
	// End newUser()

	void displayUsers()
	{
		// Loop to Display the user. (Menu option 5 - Root User Only!)
		if(activeUID == 0)
		{
			for(User u : UserList)
			{
				u.ToString();
			}
		}
		else
		{
			System.out.println("Current user does not have access to display users!");
		}
	}
	// End displayUsers()
	
	String getPassword() throws  NoSuchAlgorithmException
	{
		String password1 = "x";
		String password2 = "y";
		
		// Password Verification.
		while(!password1.equals(password2))
		{
			System.out.println("Enter the User Password:");
			password1 = sc.nextLine();
			System.out.println("Please Re-enter the Password");
			password2 = sc.nextLine();
			if(!password1.equals(password2))
			{
				System.out.println("Passwords do not match.");
			}
		}
		password1 = new String (computeHash(password1));
		return password1;
	}
	// End getPassword()	
	
	void readObject() throws ClassNotFoundException, IOException
	{
		 fis = new FileInputStream(file);
	     ois = new ObjectInputStream(fis);
		
		UserList = (ArrayList<User>) ois.readObject();
		
		ois.close();
		fis.close();
	}
	// End readObject()
	
	void writeObject() throws IOException, FileNotFoundException
	{
		fos = new FileOutputStream(file); 
        oos  = new ObjectOutputStream(fos);
		
        oos.writeObject(UserList);

		oos.close();
		fos.close();
	}
	// End writeObject

	byte[] computeHash(String password) throws NoSuchAlgorithmException  
	{
		MessageDigest d = MessageDigest.getInstance("SHA-1");
		d.update(password.getBytes());
		return  d.digest();
	}
	// End computeHash()
	
	void Login() throws NoSuchAlgorithmException, IOException
	{
		// Logging out prior user.
		Logout();
		
		String inputUser;
		String inputPassword;
		System.out.println("Enter your user name:");
		inputUser = sc.nextLine();
		System.out.println("Enter your password:");
		inputPassword = new String (computeHash(sc.nextLine()));
		activeUID = findUser(inputUser);
		if(activeUID != -1)
		{
			activeUser = UserList.get(activeUID);
			// Checking input password.
			if(inputPassword.equals(activeUser.getPassword()))
			{
				System.out.printf("Successful Login: %s\n", activeUser.UserName);
				return;
			}
		}
		System.out.println("Login Failed!");
		return;
	}
	// End Login()
	
	int findUser(String inputUser)
	{
		int size = UserList.size();
		String uname = null;
		
		for(int k = 0; k < size; ++k)
		{
			activeUser = UserList.get(k);
			uname = activeUser.UserName;
			// Comparing the inputed user name with an actual user name.
			if(inputUser.equals(uname))
			{
				UID = k; break;
			}
			else
			{ 
				UID = -1;
			}
		}
		
		return UID;
	}
	// End findUser()
	
	void changePassword() throws NoSuchAlgorithmException, IOException
	{
		// Password change options for root user.
		if(activeUID == 0)
		{
			 System.out.println("Enter the user name:");
			 String uname = sc.nextLine();
			 UID = findUser(uname);
			 if(UID == -1)
			 {
				 System.out.println("No User Found!");
				 return;
			 }
			 tempUser = UserList.get(UID);
			 tempUser.setPassword(getPassword());
		}
		// Password change options for any user.
		else if(activeUID > 0)
		{
			activeUser.setPassword(getPassword());
		}
		return;
	}
	// End changePassword()
	
	void Logout()
	{
		activeUser = null;
		activeUID = -1;
	}
	// End Logout()
}