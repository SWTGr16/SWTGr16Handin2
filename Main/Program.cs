    using System;

    class Program
    {
        static void Main(string[] args)
        {
        // Assemble your system here from all the classes

        //Mangler reference til library
        //RFIDReader _rfidReader = new RFIDReader(); 


        bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                        door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string id = System.Console.ReadLine();
                        _rfidReader.Read(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}

    
