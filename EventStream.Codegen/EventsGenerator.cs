﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace EventStream.Generator
{
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using EventStreaming;
    using EventStreaming.Configuration;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class EventsGenerator : EventsGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\n");
            this.Write("\nusing System.Collections.Generic;\nusing System.Linq;\nusing System;\nusing EventSt" +
                    "reaming;\n\nnamespace ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_namespace));
            
            #line default
            #line hidden
            this.Write("\n{\n    public class AmbientContext : IAmbientContext\n    {\n        private readon" +
                    "ly Dictionary<string, object> _dynamicValues = new Dictionary<string, object>(");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_ambientFieldDefinitions.Values.OfType<DynamicFieldDefinition>().Count()));
            
            #line default
            #line hidden
            this.Write(");\n        private readonly Dictionary<string, Func<object>> _evaluatedValues = n" +
                    "ew Dictionary<string, Func<object>>(");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_ambientFieldDefinitions.Values.OfType<EvaluatedFieldDefinition>().Count()));
            
            #line default
            #line hidden
            this.Write(@");

        public int UserSeed { get; set; }

        public object GetValue(string key)
        {
            if (_dynamicValues.TryGetValue(key, out var value))
            {
                return value;
            }
            else
            {
                if (_evaluatedValues.TryGetValue(key, out var func))
                {
                    return func();
                }
                else
                {
                    return null;
                }
            }
        }

");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 foreach(var field in _ambientFieldDefinitions.Values.OfType<DynamicFieldDefinition>()) { 
            
            #line default
            #line hidden
            this.Write("\n        public void Set");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Type.ToString().ToLowerCamelCase()));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToLowerCamelCase()));
            
            #line default
            #line hidden
            this.Write(")\n        {\n            _dynamicValues[\"");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            
            #line default
            #line hidden
            this.Write("\"] = ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToLowerCamelCase()));
            
            #line default
            #line hidden
            this.Write(";\n        }\n\n        public void Clear");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("()\n        {\n            _dynamicValues.Remove(\"");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            
            #line default
            #line hidden
            this.Write("\"); \n        }\n");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 foreach(var field in _ambientFieldDefinitions.Values.OfType<EvaluatedFieldDefinition>()) { 
            
            #line default
            #line hidden
            this.Write("\n        public void Set");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Func(Func<");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Type.ToString().ToLowerCamelCase()));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToLowerCamelCase()));
            
            #line default
            #line hidden
            this.Write(")\n        {\n            _evaluatedValues[\"");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            
            #line default
            #line hidden
            this.Write("\"] = () => ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToLowerCamelCase()));
            
            #line default
            #line hidden
            this.Write("();\n        }\n\n        public void Clear");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Func()\n        {\n            _evaluatedValues.Remove(\"");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            
            #line default
            #line hidden
            this.Write("\"); \n        }\n");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n    }\n\n    public static partial class ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_className));
            
            #line default
            #line hidden
            this.Write("\n    {\n        private static readonly KeyValuePair<string, object>[] EmptyArray " +
                    "= new KeyValuePair<string, object>[0];\n\n");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 foreach(var @event in _events) { 
            
            #line default
            #line hidden
            this.Write("\n        public static Event ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(@event.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(", ", @event.Fields.Values.OfType<DynamicFieldDefinition>().Select(f => f.Type.ToString().ToLowerCamelCase() + " " + f.Name.ToLowerCamelCase()))));
            
            #line default
            #line hidden
            this.Write(")\n        { ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 if (@event.Fields.Values.OfType<DynamicFieldDefinition>().Any()) { 
            
            #line default
            #line hidden
            this.Write(" \n            return new Event(\"");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(@event.Name));
            
            #line default
            #line hidden
            this.Write("\",\n                new []\n                { ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 foreach(var field in @event.Fields.Values.OfType<DynamicFieldDefinition>()) {
            
            #line default
            #line hidden
            this.Write("\n                    new KeyValuePair<string, object>(\"");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name));
            
            #line default
            #line hidden
            this.Write("\", ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToLowerCamelCase()));
            
            #line default
            #line hidden
            this.Write("), ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n                }); ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write(" \n            return new Event(\"");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(@event.Name));
            
            #line default
            #line hidden
            this.Write("\", EmptyArray); ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\n        } \n        ");
            
            #line 1 "C:\IrfanView\bingo.cs\Src\Playtika\EventStreaming\EventStream.Codegen\EventsGenerator.tt"
 }
            
            #line default
            #line hidden
            this.Write("\n    }\n}");
            return this.GenerationEnvironment.ToString();
        }
        private global::Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost hostValue;
        /// <summary>
        /// The current host for the text templating engine
        /// </summary>
        public virtual global::Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost Host
        {
            get
            {
                return this.hostValue;
            }
            set
            {
                this.hostValue = value;
            }
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class EventsGeneratorBase
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
