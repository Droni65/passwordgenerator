public class GeneraPassword
{
    public static void main(String[] args) throws IOException
    {
        try (final Scanner reader = new Scanner(java.lang.System.in);)
        {
            int lenNum;
            int lenUp;
            int lenSpecial;
            int lenPsw;
            int nPsw;
            lenNum = lenUp = lenSpecial = lenPsw = nPsw = -1;
            println("Generatore di password by Droni v 0.2\n");
            lenPsw = GeneraPassword.getInput(reader, "quanti caratteri deve essere lunga la password?");
            lenNum = GeneraPassword.getInput(reader, "quanti numeri deve contenere la password? (valori da 0 a " + lenPsw + ")");
            lenUp =  GeneraPassword.getInput(reader, "quante MAIUSCOLE deve contenere la password? (valori da 0 a " + lenPsw + ")");
            lenSpecial = GeneraPassword.getInput(reader, "quanti caratteri speciali deve contenere la password? (valori da 0 a " + lenPsw + ")");
            nPsw = GeneraPassword.getInput(reader, "quante password vuoi creare?");
            if (lenPsw - lenNum - lenUp - lenSpecial >= 0)
            {
                GeneraPassword gp = new GeneraPassword();
                gp.numberChar = lenNum;
                gp.upperChar = lenUp;
                gp.specialChar = lenSpecial;
                println("password consiglate: ");
                for (int i = 0; i < nPsw; i++)
                {
                    String password = gp.getPassword(lenPsw);
                    List<Character> list = gp.string2List(password);
                    println("\t${list.join('')}");
                }
            }
            else {
                println("hai esagerato!");
            }
        }
    }
    /**
    * @param reader
    * @param lenPsw
    * @param prompt
    * @return
    */
    private static int getInput(Scanner reader, String prompt)
    {
        println(prompt);
        int inputValue = -1;
        while (inputValue == -1)
        {
            try
            {
                inputValue = reader.nextInt();
            } catch (InputMismatchException e){
                print("riprova ");
                reader.nextLine();
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
    public String specialChars = "!@#.,";
    public String getPassword(int length)
    {
        Random random = new Random();
        StringBuilder sb = new StringBuilder(length);
        int chardn = length - this.specialChar - this.numberChar - this.upperChar;
        if (this.specialChar > 0)
        {
            sb.append(this.getBlockpassword(this.specialChar, random, this.specialChars));
        }
        if (this.upperChar > 0)
        {
            sb.append(this.getBlockpassword(this.upperChar, random, this.upper));
        }
        if (this.numberChar > 0)
        {
            sb.append(this.getBlockpassword(this.numberChar, random, this.numbers));
        }
        if (chardn > 0)
        {
            sb.append(this.getBlockpassword(chardn, random, this.lower));
        }
        List<Character> list = this.string2List(sb.toString());
        Collections.shuffle(list);
        StringBuilder password = new StringBuilder();
        for (int i = length; i > 0; --i)
        {
            password.append(list.get(random.nextInt(list.size())));
        }
        return list.join('');
    }
    /**
    * @param sb
    * @return
    */
    private java.util.List<Character> string2List(String sb)
    {
        char[] listc = sb.toString().toCharArray();
        List<Character> list = new java.util.ArrayList<Character>();
        for (char c : listc)
        {            list.add(c);
        }
        return list;
    }
    private String getBlockpassword(int length, Random random, String charsToProcess)
    {
        List<Character> letters = new java.util.ArrayList<Character>();
        StringBuilder password = new StringBuilder();
        for (char c : charsToProcess.toCharArray())
        {
            letters.add(c);
        }
        for (int i = length; i > 0; --i)
        {
            password.append(letters.get(random.nextInt(letters.size())));
        }
        return password.toString();
    }
}