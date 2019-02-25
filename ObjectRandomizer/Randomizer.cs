using System;


namespace ObjectRandomizer
{
    public static class Randomizer
    {
        public static long StringLength { get; set; }
        public static string AllowedChars { get; set; }
        static Random rd = new Random();

        static Randomizer()
        {
            StringLength = 10;
            AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
        }

        public static T GenerateRandom<T>()
        {

            var newObj = Activator.CreateInstance<T>();
            FillObject(ref newObj);
            return newObj;

        }
        private static void FillObject<T>(ref T obj)
        {

            var props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                var propType = prop.PropertyType;

                if (propType == typeof(string))
                {
                    string val = RandomString();
                    prop.SetValue(obj, val);
                }
                else if (propType == typeof(Int16))
                {
                    short val = (Int16)rd.Next(Int16.MinValue, Int16.MaxValue);
                    prop.SetValue(obj, val);
                }
                else if (propType == typeof(Int32))
                {
                    int val = rd.Next(Int32.MinValue, Int32.MaxValue);
                    prop.SetValue(obj, val);
                }
                else if (propType == typeof(Int64))
                {
                    //Random Maxes Out at Int32
                    long val = rd.Next(Int32.MinValue, Int32.MaxValue);
                    prop.SetValue(obj, val);
                }
                else if (propType == typeof(double))
                {
                    double val = rd.NextDouble();
                    prop.SetValue(obj, val);
                }
                else if (propType == typeof(decimal))
                {
                    decimal val =(decimal)rd.NextDouble();
                    prop.SetValue(obj, val);
                }
                else if (propType == typeof(Guid))
                {
                    Guid val = Guid.NewGuid();
                    prop.SetValue(obj, val);
                }
                else
                {
                    var propval = Activator.CreateInstance(prop.PropertyType);
                    FillObject(ref propval);
                    prop.SetValue(obj, propval);
                }

            }
            
            
        }

        
        private static string RandomString()
        {
            char[] chars = new char[StringLength];

            for (int i = 0; i < StringLength; i++)
            {
                chars[i] = AllowedChars[rd.Next(0, AllowedChars.Length)];
            }

            return new string(chars);

        }
    }
}
