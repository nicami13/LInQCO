using Demo01.Clases;
internal class Program
{
    private static void Main(string[] args)
    {
        Linq01 demoLinq01 = new Linq01();
        // demoLinq01.PrintData();

        Linq02 demoLinq02 = new Linq02();
        // demoLinq02.NameId();
        // demoLinq02.PrintDatav3();
        // demoLinq02.PrintDataV4();
        demoLinq02.StandardAgruped();

    }
}