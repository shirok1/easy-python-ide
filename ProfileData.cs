using System.Xml.Serialization;

namespace EasyPythonIde
{
    [XmlRoot(ElementName = "EasyPythonProfile")]
    public class ProfileData
    {
        [XmlElement(ElementName = "InterpreterType")]
        public int InterpreterType;
        [XmlElement(ElementName = "CustomPythonPath")]
        public string CustomPythonPath;
        [XmlElement(ElementName = "TabSpaceCount")]
        public short TabSpaceCount;
        [XmlElement(ElementName = "EditorFontName")]
        public string EditorFontName;
        [XmlElement(ElementName = "EditorFontSize")]
        public float EditorFontSize;
        [XmlElement(ElementName = "EditorFontStyle")]
        public System.Drawing.FontStyle EditorFontStyle;
        [XmlElement(ElementName = "EditorFontUnit")]
        public System.Drawing.GraphicsUnit EditorFontUnit;
        [XmlElement(ElementName = "TempRun")]
        public bool TempRun;
    }
}