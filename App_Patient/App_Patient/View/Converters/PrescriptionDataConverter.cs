namespace App_Patient.View.Converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using App_Patient.Logic.Model.Data;
    public class PrescriptionDataConverter : IValueConverter
    {
        public static bool IsAdding;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Prescription prescription = (Prescription)value;

            if (IsAdding) // Printing style when adding a prescription
            {
                return String.Format("Doctor name: {0}\nDoctor surname: {1}\nPatient name: {2}\nPatient surname: {3}\n" +
                    "Patient PESEL: {4}\nMedicine name: {5}\nMedicine amount: {6}\nDate: {7}",
                    prescription.Doctor.Name, prescription.Doctor.Surname, prescription.Patient.Name, prescription.Patient.Surname,
                    prescription.Patient.PESEL, prescription.Medicine.Name, prescription.Medicine.Amount, prescription.Date);
            }
            else // Printing style when printing prescriptions list
            {
                return String.Format("-- Medicine in your prescription: \"{0}\" in amount {1} ", prescription.Medicine.Name, prescription.Medicine.Amount);
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
