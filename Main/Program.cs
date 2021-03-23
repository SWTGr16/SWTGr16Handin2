    using System;
    using SWTGr16Handin2;
    class Program
    {
        static void Main(string[] args)
        {
        // Assemble your system here from all the classes
        IRFIDReader _rfidReader = new RFIDReader();
        IDoor _door = new Door();
        


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
                        _door.OpenDoor(); // Vi mangler disse to metoder i door
                        break;

                    case 'C':
                        _door.CloseDoor(); // Vi mangler også denne 
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

    
