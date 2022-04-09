namespace App_Doctor.View.Converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using App_Doctor.Logic.Model.Data;

    public class VisitDataConverter : IValueConverter
    {
        public static bool IsAdding;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visit visit = (Visit)value;
            if (visit.Doctor is null) //Clear
            {
                return String.Format("");
            }
            else if (IsAdding) // Printing style when adding a visit
            {
                return String.Format("Doctor name: {0}\nDoctor surname: {1}\nPatient name: {2}\nPatient surname: {3}\nPatient PESEL: {4}\nDate: {5}",
                    visit.Doctor.Name, visit.Doctor.Surname, visit.Patient.Name, visit.Patient.Surname, visit.Patient.PESEL, visit.Date);
            }
            else // Printing style when printing visits list
            {
                return String.Format("-- {0}. Visit with \"{1} {2}\"", visit.Date.ToString("D"), visit.Patient.Name, visit.Patient.Surname);
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }
}
