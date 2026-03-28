namespace MyStuff11net.Utils_Library
{
    class ListExamples
    {
        #region"How do i get the difference in two lists in C#"

        List<Attribute> attributes = new List<Attribute>();
        List<string> songs = new List<string>();
        //one is of strings and and one is of a attribute object that i created..very simple

        class Attribute
        {
            public string size { get; set; }
            public string link { get; set; }
            public string name { get; set; }
            public Attribute() { }
            public Attribute(string s, string l, string n)
            {
                size = s;
                link = l;
                name = n;
            }
        }
        //I now have to compare to see what songs are not in the attributes name so for example
        void InitializeList()
        {
            songs.Add("something");
            songs.Add("another");
            songs.Add("yet another");

            Attribute a = new Attribute("500", "http://google.com", "something");
            attributes.Add(a);
        }
        //I want a way to return "another" and "yet another" because they are not in the attributes list name

        void Answer1()
        {
            var difference = songs.Except(attributes.Select(s => s.name)).ToList();
        }

        /*It's worth pointing out that the answers posted here will return a list of songs not present in
          attributes.names, but it won't give you a list of attributes.names not present in songs.
            While this is what the OP wanted, the title may be a little misleading, especially if (like me
         you came here looking for a way to check whether the contents of two lists differ. If this is what
         you want, you can use the following:- */

        void Answer2()
        {
            var differences = new HashSet<string>(songs);
            differences.SymmetricExceptWith(attributes.Select(a => a.name));
            if (differences.Any())
            {
                // The lists differ.
            }
        }

        void Answer3()
        {
            // Create the IEnumerable data sources. 
            string[] names1 = System.IO.File.ReadAllLines(@"../../../names1.txt");
            string[] names2 = System.IO.File.ReadAllLines(@"../../../names2.txt");

            // Create the query. Note that method syntax must be used here.
            IEnumerable<string> differenceQuery =
              names1.Except(names2);

            // Execute the query.
            Console.WriteLine("The following lines are in names1.txt but not names2.txt");
            foreach (string s in differenceQuery)
                Console.WriteLine(s);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            /* Output:
            The following lines are in names1.txt but not names2.txt
            Potra, Cristina
            Noriega, Fabricio
            Aw, Kam Foo
            Toyoshima, Tim
            Guy, Wey Yuan
            Garcia, Debra
            */
        }

        #endregion"How do i get the difference in two lists in C#"

        #region"Joining Multiple Inputs into One Output Sequence"

        /*You can use a LINQ query to create an output sequence that contains elements from more than
         one input sequence. The following example shows how to combine two in-memory data structures,
         but the same principles can be applied to combine data from XML or SQL or DataSet sources.
            Assume the following two class types: */

        class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public List<int> Scores;
        }

        class Teacher
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public string City { get; set; }
        }

        void listExample()
        {
            // Create the first data source.
            List<Student> students = new List<Student>()
            {
                new Student {First="Svetlana",
                    Last="Omelchenko",
                    ID=111,
                    Street="123 Main Street",
                    City="Seattle",
                    Scores= new List<int> {97, 92, 81, 60}},
                new Student {First="Claire",
                    Last="O’Donnell",
                    ID=112,
                    Street="124 Main Street",
                    City="Redmond",
                    Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven",
                    Last="Mortensen",
                    ID=113,
                    Street="125 Main Street",
                    City="Lake City",
                    Scores= new List<int> {88, 94, 65, 91}},
            };

            // Create the second data source.
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher {First="Ann", Last="Beebe", ID=945, City = "Seattle"},
                new Teacher {First="Alex", Last="Robinson", ID=956, City = "Redmond"},
                new Teacher {First="Michiyo", Last="Sato", ID=972, City = "Tacoma"}
            };

            // Create the query. 
            var peopleInSeattle = (from student in students
                                   where student.City == "Seattle"
                                   select student.Last)
                           .Concat(from teacher in teachers
                                   where teacher.City == "Seattle"
                                   select teacher.Last);

            Console.WriteLine("The following students and teachers live in Seattle:");
            // Execute the query. 
            foreach (var person in peopleInSeattle)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            /* Output:
            The following students and teachers live in Seattle:
            Omelchenko
            Beebe
         */
        }

        #endregion"Joining Multiple Inputs into One Output Sequence"

    }


}

