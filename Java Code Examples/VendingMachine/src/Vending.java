/** Vending.java
    Emulate a vending machine that sells bus tickets.
    @author    Alice E. Fischer
    		   Louis Notarino
    @version   February 7, 2013
*/
//  ----------------------------------------------------------------------------
import java.util.*;

public class Vending {
    private final double adult;             // Price of one regular ticket.
    private final double child;             // Child's ticket is half price.
    private final double senior;            // Senior ticket is 80%

    private Scanner sc = new Scanner(System.in);

    /** Initialize a vending machine to sell tickets at a fixed base price. 
     *     Tickets for children are half price, and seniors are 80%.
     *  @param price  The base ticket price, for an adult rider.
     */
    public Vending( double price )
    {
        adult = price;
        child  = Math.ceil( 100 *( 0.5 * price)) / 100;      // Round the fraction up.
        senior = Math.ceil( 100 *( 0.8 * price)) / 100;      // Round the fraction up.
    }

    /** Dispense bus tickets to be paid for by a credit card. Adult, child, and 
	    senior tickets may be purchased.
     */
    public void go() {
        double price; // If there is no default below, use   price = 0;
        int choice = 0, quantity = 0;
        double total_price = 0;

        System.out.println("\nBus Ticket Vending Machine");
        while(choice != 5)
        {
        	System.out.printf ("    1. Adult %.2f\n    2. Child under 12 %.2f\n", adult, child);
        	System.out.printf ("    3. Senior Citizen %.2f\n", senior);
        	for(;;)
        	{
        		System.out.println("Please select 1, 2, 3 and enter the quantity.\n"+
        						   "Select 4 to Cancel. \nSelect 5 to Finish & Pay.\n");
        		choice = sc.nextInt();
        		//Cancel Option
        		if (choice == 4)
        		{
        			System.out.println("Transaction Canceled...");
        			System.out.println("GoodBye");
        			System.exit(1);
        		}
        		else if (choice == 5)
        		{
        			System.out.printf("Total price: %.2f", total_price);
        			System.out.println("\nPlease swipe your credit card, then take your tickets.");
        			System.exit(1);
        		}
        		else if (choice>0 && choice<4) break;
        		String junk = sc.nextLine();   // Discard chars to end of line.
        		System.out.printf("Bad menu choice:  %s %s\n", choice, junk);
        	}
        	quantity = sc.nextInt(); 
        
        	//Validation loop for quantity.
        	while (quantity<0 || quantity>10)
        	{
        		System.out.println("Quantity must be between 0 and 10.");
        		System.out.printf("Bad Quantity choice:  %s\n", quantity);
        		System.out.printf("Enter a new Quantity for your selection %s.\n", choice);
        		quantity = sc.nextInt();
        	}
        	switch (choice)
        	{
        		case 1: price = adult; break;
        		case 2: price = child; break;
        		case 3: price = senior; break;
        		default: price = 0;   
        	}
        	//Display the type of types and quantity selected.
	        if (choice == 1)
	        {
	        	System.out.printf("You selected %s Adult ticket(s)\n",quantity);
	        }
	        else if (choice == 2)
	        {
	        	System.out.printf("You selected %s Child ticket(s)\n",quantity);
	        }
	        else if (choice == 3)
	        {
	        	System.out.printf("You selected %s Senior Citizen ticket(s)\n",quantity);
	        }
	        total_price += (quantity * price);
	        total_price = Math.ceil( 100 * total_price) / 100;
        }
    }

    //    -------------------------------------------------------------------------------------------
    public static void main (String args[])
    {
        Vending V = new Vending( 2.25 );
        V.go();
    }
}


/* -----------------------------------------------------------------------------

Bus Ticket Vending Machine
    1. Adult 2.25
    2. Child under 12 1.13
    3. Senior Citizen 1.80
Please select 1, 2, or 3 and enter the quantity.

1 4
Total price: 9.00
Please swipe your credit card, then take your tickets.
===========================

Bus Ticket Vending Machine
    1. Adult 2.25
    2. Child under 12 1.13
    3. Senior Citizen 1.80
Please select 1, 2, or 3 and enter the quantity.

2 2
Total price: 2.26
Please swipe your credit card, then take your tickets.

===========================

Bus Ticket Vending Machine
    1. Adult 2.25
    2. Child under 12 1.13
    3. Senior Citizen 1.80
Please select 1, 2, or 3 and enter the quantity.

3 3
Total price: 5.40
Please swipe your credit card, then take your tickets.

===========================

Bus Ticket Vending Machine
    1. Adult 2.25
    2. Child under 12 1.13
    3. Senior Citizen 1.80
Please select 1, 2, 3 and enter the quantity.

4 2
Bad menu choice:  4  2
Please select 1, 2, 3 and enter the quantity.

3 2
Total price: 3.60
Please swipe your credit card, then take your tickets.

==========================

Bus Ticket Vending Machine
    1. Adult 2.25
    2. Child under 12 1.13
    3. Senior Citizen 1.80
Please select 1, 2, 3 and enter the quantity.
Select 4 to Cancel. 
Select 5 to Finish & Pay.

6 3
Bad menu choice:  6  3
Please select 1, 2, 3 and enter the quantity.
Select 4 to Cancel. 
Select 5 to Finish & Pay.

1 12
Quantity must be between 0 and 10.
Bad Quantity choice:  12
Enter a new Quantity for your selection 1.
2
You selected 2 Adult ticket(s)
    1. Adult 2.25
    2. Child under 12 1.13
    3. Senior Citizen 1.80
Please select 1, 2, 3 and enter the quantity.
Select 4 to Cancel. 
Select 5 to Finish & Pay.

1 2
You selected 2 Adult ticket(s)
    1. Adult 2.25
    2. Child under 12 1.13
    3. Senior Citizen 1.80
Please select 1, 2, 3 and enter the quantity.
Select 4 to Cancel. 
Select 5 to Finish & Pay.

2 4
You selected 4 Child ticket(s)
    1. Adult 2.25
    2. Child under 12 1.13
    3. Senior Citizen 1.80
Please select 1, 2, 3 and enter the quantity.
Select 4 to Cancel. 
Select 5 to Finish & Pay.

5
Total price: 13.52
Please swipe your credit card, then take your tickets.

------------------------------------------------------------------------------*/