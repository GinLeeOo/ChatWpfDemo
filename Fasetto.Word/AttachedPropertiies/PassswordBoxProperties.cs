using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
public     class PassswordBoxProperties
    {

      //  public bool HasText { get; set } = false;

        public static readonly DependencyProperty HasTextProperty = 
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PassswordBoxProperties), new PropertyMetadata(false));

        private static void  SetHasText(PasswordBox element) => element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);

        private static bool GetHasText(PasswordBox element)=> (bool)element.GetValue(HasTextProperty);
    
    }
}
