using GameOfLife.Models;
using System.Reflection;

namespace GameOfLife
{
    public partial class NewSimulationDialogForm : Form
    {
        private static readonly Type interfaceType = typeof(ISimulation);
        private static readonly IEnumerable<Type> simulationTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => interfaceType.IsAssignableFrom(type) 
                && !type.IsInterface 
                && HasDefaultConstructor(type));

        private Type simulationType;
        public Type SimulationType => simulationType;

        public NewSimulationDialogForm()
        {
            InitializeComponent();
        }

        private static bool HasDefaultConstructor(Type type)
        {
            return type.GetConstructors().Where(constructor => constructor.GetParameters().Length == 0).Any();
        }

        private void NewSimulationDialogForm_Load(object sender, EventArgs e)
        {
            var simulationNames = simulationTypes.Select(type => type.Name).ToArray();
            simulationTypeComboBox.Items.Clear();
            simulationTypeComboBox.MaxDropDownItems = simulationNames.Length;
            simulationTypeComboBox.Items.AddRange(simulationNames);
            if (simulationNames.Length > 0)
            {
                simulationTypeComboBox.SelectedItem = simulationTypeComboBox.Items[0];
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            simulationType = simulationTypes.First(type => String.Equals(type.Name, simulationTypeComboBox.SelectedItem.ToString()));
        }
    }
}
