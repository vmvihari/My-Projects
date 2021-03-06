icao('A', 'Alfa').
icao('B', 'Bravo').
icao('C', 'Charlie').
icao('D', 'Delta').
icao('E', 'Echo').
icao('F', 'Foxtrot').
icao('G', 'Golf').
icao('H', 'Hotel').
icao('I', 'India').
icao('J', 'Juliett').
icao('K', 'Kilo').
icao('L', 'Lima').
icao('M', 'Mike').
icao('N', 'November').
icao('O', 'Oscar').
icao('P', 'Papa').
icao('Q', 'Quebec').
icao('R', 'Romeo').
icao('S', 'Sierra').
icao('T', 'Tango').
icao('U', 'Uniform').
icao('V', 'Victor').
icao('W', 'Whiskey').
icao('X', 'X-ray').
icao('Y', 'Yankee').
icao('Z', 'Zulu').
icao(' ', ' ').

printIcao([Head|Tail]):-
	icao(Head, Result),
	writeln(Result),
	printIcao(Tail).

convertToIcao(StrPhrase):-
	string_upper(StrPhrase, UpPhrase),
	string_chars(UpPhrase, LstChars),
	printIcao(LstChars).

morse('A', '.-').
morse('B', '-...').
morse('C', '-.-.').
morse('D', '-..').
morse('E', '.').
morse('F', '..-.').
morse('G', '--.').
morse('H', '....').
morse('I', '..').
morse('J', '.---').
morse('K', '-.-').
morse('L', '.-..').
morse('M', '--').
morse('N', '-.').
morse('O', '---').
morse('P', '.--.').
morse('Q', '--.-').
morse('R', '.-.').
morse('S', '...').
morse('T', '-').
morse('U', '..-').
morse('V', '...-').
morse('W', '.--').
morse('X', '-..-').
morse('Y', '-.--').
morse('Z', '--..').
morse('0', '-----').
morse('1', '.----').
morse('2', '..---').
morse('3', '...--').
morse('4', '....-').
morse('5', '.....').
morse('6', '-....').
morse('7', '--...').
morse('8', '---..').
morse('9', '----.').
morse(' ', '/').

printMorse([Head|Tail]):-
	(is_alnum(Head) -> morse(Head, Result); Result = Head),
	write(Result),
	write(' '),
	length(Tail,LstLength),
	(LstLength > 0 -> printMorse(Tail); writeln('')).

printChar([Head|Tail]):-
	atom_string(AtomHead, Head),
	morse(Result, AtomHead),
	write(Result),
	length(Tail,LstLength),
	(LstLength > 0 -> printChar(Tail); writeln('')).

convertToMorse(StrPhrase):-
	string_upper(StrPhrase, UpPhrase),
	string_chars(UpPhrase, LstChars),
	printMorse(LstChars).

convertFromMorse(StrEncodePhrase):-
	split_string(StrEncodePhrase, " ", "\s\t\n", LstEncodePhrase),
	printChar(LstEncodePhrase).














