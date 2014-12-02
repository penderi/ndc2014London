using System;

namespace Common.Assets
{
    public class CsObjectToBindToJsVm
    {
        public delegate void calledFromCs(string fromCs);
        public event calledFromCs CalledFromCs;

        public void sentFromUI(string fromUI)
        {
            Console.WriteLine(fromUI);
            if (CalledFromCs != null)
            {
                CalledFromCs("Returning what was sent " + fromUI);
            }
        }

    }
}