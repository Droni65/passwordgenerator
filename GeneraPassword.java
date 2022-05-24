package testVari;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.InputMismatchException;
import java.util.List;
import java.util.Random;
import java.util.Scanner;
import java.util.stream.Collectors;

public class GeneraPassword {

	public static void main(String[] args) throws IOException {

		try (Scanner reader = new Scanner(System.in)) {
			int lenNum, lenUp,lenSpecial,lenPsw,nPsw;
			lenNum= lenUp=lenSpecial=lenPsw=nPsw=-1;
			System.out.println("Generatore di password by Droni v 0.2\n");
			lenPsw     = getInput(reader, "quanti caratteri deve essere lunga la password?");
			lenNum     = getInput(reader, "quanti numeri deve contenere la password? (valori da 0 a " + lenPsw + ")");
			lenUp      = getInput(reader, "quante MAIUSCOLE deve contenere la password? (valori da 0 a " + lenPsw + ")");
			lenSpecial = getInput(reader, "quanti caratteri speciali deve contenere la password? (valori da 0 a " + lenPsw + ")");
			nPsw       = getInput(reader, "quante password vuoi creare?");
			if (lenPsw - lenNum - lenUp - lenSpecial >= 0) {
				GeneraPassword gp = new GeneraPassword();
				gp.numberChar = lenNum;
				gp.upperChar = lenUp;
				gp.specialChar = lenSpecial;

				System.out.println("password consiglate: ");
				for (int i = 0; i < nPsw; i++) {
					String password = gp.getPassword(lenPsw);
					List<Character> list = gp.string2List(password);
					System.out.println("\t"+list.stream().map(String::valueOf).collect(Collectors.joining()));
				}
			} else {
				System.err.println("hai esagerato!");
			}
		}
	}

	/**
	 * @param reader
	 * @param lenPsw
	 * @param prompt
	 * @return
	 */
	private static int getInput(Scanner reader, String prompt) {
		System.out.println(prompt);
		int inputValue = -1;
		while( inputValue == -1) {	
			try {
			inputValue = reader.nextInt();
			} catch (InputMismatchException e) {
				System.out.print( "riprova ");
				reader.nextLine();
			}
		}
		return inputValue;
	}

	public int specialChar = 0;
	public int upperChar = 0;
	public int numberChar = 0;

	String upper = "ABCDEFGHIJKLMNPQRSTUVWXYZ"; // la O si confonde con lo zero
	String lower = "abcdefghijkmnopqrstuvwxyz"; // la elle(l) si confonde con 1(uno)
	String numbers = "0123456789";
	String specialChars = "!@#.,$";

	String getPassword(int length) {
		Random random = new Random();
		StringBuilder sb = new StringBuilder(length);

		int chardn = length - specialChar - numberChar - upperChar;

		if (specialChar > 0)
			sb.append(getBlockpassword(specialChar, random, specialChars));
		if (upperChar > 0)
			sb.append(getBlockpassword(upperChar, random, upper));
		if (numberChar > 0)
			sb.append(getBlockpassword(numberChar, random, numbers));
		if (chardn > 0)
			sb.append(getBlockpassword(chardn, random, lower));

		List<Character> list = string2List(sb.toString());
		Collections.shuffle(list);

		StringBuilder password = new StringBuilder();
		for (int i = length; i > 0; --i) {
			password.append(list.get(random.nextInt(list.size())));
		}
		return list.stream().map(String::valueOf).collect(Collectors.joining());
	}

	/**
	 * @param sb
	 * @return
	 */
	private List<Character> string2List(String sb) {
		char[] listc = sb.toString().toCharArray();
		List<Character> list = new ArrayList<Character>();
		for (char c : listc)
			list.add(c);
		return list;
	}

	private String getBlockpassword(int length, Random random, String charsToProcess) {
		List<Character> letters = new ArrayList<Character>();
		StringBuilder password = new StringBuilder();

		for (char c : charsToProcess.toCharArray()) {
			letters.add(c);
		}

		for (int i = length; i > 0; --i) {
			password.append(letters.get(random.nextInt(letters.size())));
		}
		return password.toString();
	}
}
