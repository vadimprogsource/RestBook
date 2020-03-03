using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Generator
{
    public class PinCodeGenerator
    {
        private int m_pin_code = 0;

        public string GenerateNextPinCode()
        {
            m_pin_code = new Random().Next(1001, 9999);
            return m_pin_code.ToString();
        }

        public string GetLastPinCode() => m_pin_code.ToString();

    }
}
