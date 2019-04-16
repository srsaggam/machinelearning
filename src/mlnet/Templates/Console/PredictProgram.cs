﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.ML.CLI.Templates.Console
{
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using Microsoft.ML.CLI.Utilities;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class PredictProgram : PredictProgramBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using System;
using System.Linq;
using Microsoft.ML;
using ");
            
            #line 17 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(".Model.DataModels;\r\n\r\n\r\nnamespace ");
            
            #line 20 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(".ConsoleApp\r\n{\r\n    class Program\r\n    {\r\n        //Machine Learning model to loa" +
                    "d and use for predictions\r\n        private const string MODEL_FILEPATH = @\"MLMod" +
                    "el.zip\";\r\n\r\n        //Dataset to use for predictions \r\n");
            
            #line 28 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
if(string.IsNullOrEmpty(TestDataPath)){ 
            
            #line default
            #line hidden
            this.Write("        private const string DATA_FILEPATH = @\"");
            
            #line 29 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TrainDataPath));
            
            #line default
            #line hidden
            this.Write("\";\r\n");
            
            #line 30 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
 } else{ 
            
            #line default
            #line hidden
            this.Write("        private const string DATA_FILEPATH = @\"");
            
            #line 31 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TestDataPath));
            
            #line default
            #line hidden
            this.Write("\";\r\n");
            
            #line 32 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"
        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext();

            // Training code used by ML.NET CLI and AutoML to generate the model
            //ModelBuilder.CreateModel();

            ITransformer mlModel = mlContext.Model.Load(MODEL_FILEPATH, out DataViewSchema inputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<SampleObservation, SamplePrediction>(mlModel);

            // Create sample data to do a single prediction with it 
            SampleObservation sampleData = CreateSingleDataSample(mlContext, DATA_FILEPATH);

            // Try a single prediction
            SamplePrediction predictionResult = predEngine.Predict(sampleData);

");
            
            #line 50 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
if("BinaryClassification".Equals(TaskType)){ 
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine($\"Single Prediction --> Actual value: {sampleData.");
            
            #line 51 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.Normalize(LabelName)));
            
            #line default
            #line hidden
            this.Write("} | Predicted value: {predictionResult.Prediction}\");\r\n");
            
            #line 52 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
}else if("Regression".Equals(TaskType)){
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine($\"Single Prediction --> Actual value: {sampleData.");
            
            #line 53 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.Normalize(LabelName)));
            
            #line default
            #line hidden
            this.Write("} | Predicted value: {predictionResult.Score}\");\r\n");
            
            #line 54 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
} else if("MulticlassClassification".Equals(TaskType)){
            
            #line default
            #line hidden
            this.Write("            Console.WriteLine($\"Single Prediction --> Actual value: {sampleData.");
            
            #line 55 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Utils.Normalize(LabelName)));
            
            #line default
            #line hidden
            this.Write("} | Predicted value: {predictionResult.Prediction} | Predicted scores: [{String.J" +
                    "oin(\",\", predictionResult.Score)}]\");\r\n");
            
            #line 56 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
}
            
            #line default
            #line hidden
            this.Write(@"
            Console.WriteLine(""=============== End of process, hit any key to finish ==============="");
            Console.ReadKey();
        }

        // Method to load single row of data to try a single prediction
        // You can change this code and create your own sample data here (Hardcoded or from any source)
        private static SampleObservation CreateSingleDataSample(MLContext mlContext, string dataFilePath)
        {
            // Read dataset to get a single row for trying a prediction          
            IDataView dataView = mlContext.Data.LoadFromTextFile<SampleObservation>(
                                            path: dataFilePath,
                                            hasHeader : ");
            
            #line 69 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(HasHeader.ToString().ToLowerInvariant()));
            
            #line default
            #line hidden
            this.Write(",\r\n                                            separatorChar : \'");
            
            #line 70 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Regex.Escape(Separator.ToString())));
            
            #line default
            #line hidden
            this.Write("\',\r\n                                            allowQuoting : ");
            
            #line 71 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AllowQuoting.ToString().ToLowerInvariant()));
            
            #line default
            #line hidden
            this.Write(",\r\n                                            allowSparse: ");
            
            #line 72 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AllowSparse.ToString().ToLowerInvariant()));
            
            #line default
            #line hidden
            this.Write(@");

            // Here (SampleObservation object) you could provide new test data, hardcoded or from the end-user application, instead of the row from the file.
            SampleObservation sampleForPrediction = mlContext.Data.CreateEnumerable<SampleObservation>(dataView, false)
                                                                        .First();
            return sampleForPrediction;
        }
    }
}
");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 81 "E:\src\machinelearning\src\mlnet\Templates\Console\PredictProgram.tt"

public string TaskType {get;set;}
public string Namespace {get;set;}
public string LabelName {get;set;}
public string TestDataPath {get;set;}
public string TrainDataPath {get;set;}
public char Separator {get;set;}
public bool AllowQuoting {get;set;}
public bool AllowSparse {get;set;}
public bool HasHeader {get;set;}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class PredictProgramBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
