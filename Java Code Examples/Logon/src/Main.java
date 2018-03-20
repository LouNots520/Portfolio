import java.io.IOException;
import java.security.NoSuchAlgorithmException;

public class Main 
{
	public static void main(String[] args) throws IOException, ClassNotFoundException, NoSuchAlgorithmException
	{
		System.out.println("Louis Notarino -- Files -- CS210");
		
		// Creating Admin Object
		Admin administrator = new Admin();
		administrator.doMenu();
	}
	
}
