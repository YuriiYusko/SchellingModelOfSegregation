using Spectre.Console;

namespace SchellingModelOfSegregation
{
    internal class Сitizens
    {
        public Сitizens(int i)
        {
            switch(i)
            {
                case 1:
                    this.color = Color.Red;            
                break;
                case 2:
                    this.color = Color.Blue;
                break;
            }
        }

        public Color color { get; private set; }
    }
}
