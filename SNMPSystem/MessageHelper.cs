using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SNMPSystem
{
    class MessageHelper
    {
        public static void ConexionError()
        {
            MessageBox.Show("An error occurred!! Please check your connection", "Conexion Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void SuccessfulOperation()
        {
            MessageBox.Show("Information saved successfully", "Successfuk Operation",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
