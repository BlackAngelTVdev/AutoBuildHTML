using System;
using System.IO;

class autobildHTML
{
    static void Main(string[] args)
    {
        // Demander à l'utilisateur de spécifier la lettre du disque
        string driveLetter;
        string basePath;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Entrez la lettre du disque (par exemple, F): ");
        Console.ResetColor();
        driveLetter = Console.ReadLine().ToUpper();

        // Vérifier que l'utilisateur entre bien une lettre de lecteur valide
        if (driveLetter.Length == 1 && Char.IsLetter(driveLetter[0]))
        {
            basePath = driveLetter + ":\\html css\\ex";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erreur : Lettre du disque invalide. Le programme va se fermer.");
            Console.ResetColor();
            return; // Quitter si la lettre du disque est invalide
        }

        string name;
        string mainFolderPath;
        bool nameok = false;

        do
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Entrez le nom du dossier principal : ");
            Console.ResetColor();
            name = Console.ReadLine();

            // Vérification si le dossier existe déjà
            mainFolderPath = Path.Combine(basePath, name);
            if (Directory.Exists(mainFolderPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erreur : Un dossier avec le nom '{name}' existe déjà. Veuillez entrer un autre nom.");
                Console.ResetColor();
            }
            else
            {
                nameok = true;
            }
        } while (!nameok);

        // Création du dossier principal
        Directory.CreateDirectory(mainFolderPath);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Dossier principal créé : {mainFolderPath}");
        Console.ResetColor();

        // Création du fichier principal dans le dossier principal
        string mainFilePath = Path.Combine(mainFolderPath, "index.html");
        string mainFileContent = "<!DOCTYPE html>\r" +
                                    "\n<html lang=\"fr\">\n" +
                                    "<head>\n" +
                                    "\t<meta charset=\"UTF-8\">\n" +
                                    "\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n" +
                                    "\t<link rel=\"stylesheet\" href=\"./media/css/style.css\">\n" +
                                    $"\t<title>{name}</title>\n" +
                                    "</head>\n" +
                                    "<body>\n" +
                                    $"\t<h1>Bienvenue dans {name}</h1>\n" +
                                    "</body>\n" +
                                    "</html>";
        File.WriteAllText(mainFilePath, mainFileContent);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Fichier créé : {mainFilePath}");
        Console.ResetColor();

        // Création du dossier media
        string mediaFolderPath = Path.Combine(mainFolderPath, "media");
        Directory.CreateDirectory(mediaFolderPath);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  Dossier media créé : {mediaFolderPath}");
        Console.ResetColor();

        // Sous-dossiers dans media
        string[] subfolders = { "img", "css", "js", "fonts" };
        foreach (string subfolder in subfolders)
        {
            string subfolderPath = Path.Combine(mediaFolderPath, subfolder);
            Directory.CreateDirectory(subfolderPath);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"    Sous-dossier créé : {subfolderPath}");
            Console.ResetColor();
        }

        // Création du fichier style.css dans le dossier css
        string cssFilePath = Path.Combine(mediaFolderPath, "css", "style.css");
        string cssFileContent = "body {\n" +
                                "    font-family: Arial, sans-serif;\n" +
                                "    margin: 0;\n" +
                                "    padding: 0;\n" +
                                "    background-color: #f4f4f4;\n" +
                                "    color: #333;\n" +
                                "}\n\n" +
                                "h1 {\n" +
                                "    color: #007BFF;\n" +
                                "    text-align: center;\n" +
                                "    margin-top: 50px;\n" +
                                "}";
        File.WriteAllText(cssFilePath, cssFileContent);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"    Fichier CSS créé : {cssFilePath}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Structure de dossiers et fichiers créée avec succès.");
        Console.ResetColor();
        Console.Write("Voulez-vous créer un autre projet ? (O/N) ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string response = Console.ReadLine();
        Console.ResetColor();
        if (response == "o" || response == "O")
        {
            Console.Clear();
            Main(null);
        }
        else
        {
            Environment.Exit(0);
        }
    }
}
