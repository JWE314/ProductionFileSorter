namespace QueryCompareDirs
{

    class CompareDirs
    {

        static void Main(string[] args)
        {

            //Create two new folders to be compared
            string pathA = @"T:\Purchasing\101-00071 GRN's";
            string pathB = @"T:\Purchasing\101-00071 GRN's\Inkron";
            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(pathA);
            System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(pathB);

            // Read file names and write to lists.
            IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            //Compare file function
            FileCompare myFileCompare = new FileCompare();

            // Find the entries that differ between the two folders.
            var queryList1Only = (from file in list1 select file).Except(list2, myFileCompare);
            Console.WriteLine("The following files are in list1 but not list2:");
            foreach (var v in queryList1Only)
            {
                Console.WriteLine(v.FullName);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}