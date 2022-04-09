namespace App_Doctor.Model
{
    using App_Doctor.Logic.Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatch) : base(dispatch)
        {
        }
    }
}
