// Include namespace system
using System;
using System.Text;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Collections;

public class GeneraPassword
{
    public static void Main(String[] args)
    {
        
        int lenNum;
        int lenUp;
        int lenSpecial;
        int lenPsw;
        int nPsw;
        lenNum = lenUp = lenSpecial = lenPsw = nPsw = -1;
        Console.WriteLine("Generatore di password by Droni v 0.2\n");
        lenPsw = getInput( "quanti caratteri deve essere lunga la password?");
        lenNum = GeneraPassword.getInput( "quanti numeri deve contenere la password? (valori da 0 a " + lenPsw.ToString() + ")");
        lenUp = GeneraPassword.getInput( "quante MAIUSCOLE deve contenere la password? (valori da 0 a " + lenPsw.ToString() + ")");
        lenSpecial = GeneraPassword.getInput( "quanti caratteri speciali deve contenere la password? (valori da 0 a " + lenPsw.ToString() + ")");
        nPsw = GeneraPassword.getInput( "quante password vuoi creare?");
        if (lenPsw - lenNum - lenUp - lenSpecial >= 0)
        {
            var gp = new GeneraPassword();
            gp.numberChar = lenNum;
            gp.upperChar = lenUp;
            gp.specialChar = lenSpecial;
            Console.WriteLine("password consiglate: ");
            for (int i = 0; i < nPsw; i++)
            {
                var password = gp.getPassword(lenPsw);
                var list = gp.string2List(password);
                //Console.WriteLine("\t" + list.stream().map(String::valueOf).collect(Collectors.joining()));
                Console.WriteLine("\t" + string.Join("", list));
            }
        }
        else
        {
            Console.WriteLine("hai esagerato!");
        }
    }

    private static int getInput( String prompt)
    {
        Console.WriteLine(prompt);
        var inputValue = -1;
        while (inputValue == -1)
        {
            try
            {
                inputValue = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Write("riprova ");
                Console.ReadLine();
            }
        }
        return inputValue;
    }

    public int specialChar = 0;
    public int upperChar = 0;
    public int numberChar = 0;
    public String upper = "ABCDEFGHIJKLMNPQRSTUVWXYZ";
    // la O si confonde con lo zero
    public String lower = "abcdefghijkmnopqrstuvwxyz";
    // la elle(l) si confonde con 1(uno)
    public String numbers = "0123456789";
    public String specialChars = "!@#.,$";
    public String getPassword(int length)
    {
        var random = new Random();
        var sb = new StringBuilder(length);
        var chardn = length - this.specialChar - this.numberChar - this.upperChar;
        if (this.specialChar > 0)
        {
            sb.Append(getBlockpassword(this.specialChar, random, this.specialChars));
        }
        if (this.upperChar > 0)
        {
            sb.Append(getBlockpassword(this.upperChar, random, this.upper));
        }
        if (this.numberChar > 0)
        {
            sb.Append(this.getBlockpassword(this.numberChar, random, this.numbers));
        }
        if (chardn > 0)
        {
            sb.Append(this.getBlockpassword(chardn, random, this.lower));
        }
        var list = this.string2List(sb.ToString());
        //Collections.shuffle(list);
        list = list.OrderBy(x => random.Next()).ToList();
        var password = new StringBuilder();
        for (int i = length; i > 0; --i)
        {
            password.Append(list[random.Next(0,list.Count)]);
        }
        return string.Join("", list);
    }
    // *
    // 	 * @param sb
    // 	 * @return
    private List<char> string2List(String sb)
    {
        char[] listc = sb.ToString().ToCharArray();
        var list = new List<char>();
        foreach (char c in listc)
        {
            list.Add(c);
        }
        return list;
    }
    private String getBlockpassword(int length, Random random, String charsToProcess)
    {
        var letters = new List<char>();
        var password = new StringBuilder();
        foreach (char c in charsToProcess.ToCharArray())
        {
            letters.Add(c);
        }
        for (int i = length; i > 0; --i)
        {
            password.Append(letters[random.Next(0,letters.Count)]);
        }
        return password.ToString();
    }

}