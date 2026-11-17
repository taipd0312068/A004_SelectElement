using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A002_SelectElement
{
    [Autodesk.Revit.Attributes.Transaction(
        Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class A005 : IExternalCommand
    {
        public Result Execute( ExternalCommandData commandData,ref string message,ElementSet elements)
        {
       
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            TaskDialog.Show("Revit", "Số lượng đối tượng được chọn: " + selectedIds.Count.ToString());
            ICollection<ElementId> selectedWallIds = new List<ElementId>();
            foreach (ElementId id in selectedIds)
            {
                Element elements1 = uidoc.Document.GetElement(id);
                if (elements1 is Wall)
                {
                    selectedWallIds.Add(id);
                }
            }
            // Set the created element set as current select element set.
            uidoc.Selection.SetElementIds(selectedWallIds);
            if (0 != selectedWallIds.Count)
            {
                TaskDialog.Show("Revit", selectedWallIds.Count.ToString() + " Đối tượng Tường đã được chọn!");
            }
            else
            {
                TaskDialog.Show("Revit", "Không có đối tượng tường nào được chọn!");
            }



            return Result.Succeeded;
        }
    }
}
