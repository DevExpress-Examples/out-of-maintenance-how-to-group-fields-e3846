using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Xml.Serialization;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_GroupingFields {
    public partial class MainPage : UserControl {
        string dataFileName = "DXPivotGrid_GroupingFields.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));
            object dataSource = s.Deserialize(stream);

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = dataSource;

            // Create a group at run-time
            PivotGridGroup group = pivotGridControl1.Groups.Add(fieldQuarter, fieldMonth);
        }
    }
}
