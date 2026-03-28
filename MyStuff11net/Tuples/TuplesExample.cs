namespace MyStuff11net.Tuples
{
    class TuplesExample
    {
        //Now, we can name each field in the Tuple like this:
        static (string name, string blog, int age) GetNameBlogAndAge()
        {
            return ("Nikola Zivkovic", "RubiksCode", 30);
        }

        //Or assigning element names inside literal itself, like this:
        static (string name, string blog, int age) GetNameBlogAndAge2()
        {
            return (name: "Nikola", blog: "RubiksCode", age: 30);
        }

        void Test()
        {
            //So, consuming Tuple can be done in a more natural way:
            var nameBlogAge = GetNameBlogAndAge();
            Console.WriteLine($"Name is: {nameBlogAge.name}");
            //The other thing that is also very useful is that tuples now can be used in deconstructing declaration.This is best shown in the example:

            (string name, string blog, int age) = GetNameBlogAndAge();
            Console.WriteLine($"Name is: {name}");
            //This means that you can split tuple into its elements and assign those elements separately to new variables.
        }
    }
}
