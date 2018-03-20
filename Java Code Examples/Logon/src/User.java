import java.io.Serializable;

public class User implements Serializable
{

	final String FullName;
	final String UserName;
	private String Password;
	
	// Creating User Constructor.
	User(String fname, String uname, String newpassword)
	{
		FullName = fname;
		UserName = uname;
		Password = newpassword;
	}
	String getFullname()
	{
		return FullName;
	}
	String getUsername()
	{
		return UserName;
	}
	String getPassword()
	{
		return Password;
	}
	void setPassword(String newpassword)
	{
		Password = newpassword;
	}
	void ToString()
	{
		System.out.println(FullName + ", " + UserName);
	}
}
