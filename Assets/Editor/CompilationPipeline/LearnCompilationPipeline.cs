using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace Editor.LearnCompilationPipeline
{
    public class LearnCompilationPipeline: EditorWindow
    {
        [MenuItem("Editor/LearnCompilationPipeline")]
        private static void OpenWindow()
        {
            EditorWindow window = GetWindow<LearnCompilationPipeline>();
            window.Show();
        }
        
        private void OnEnable()
        {
            // CompilationPipeline.compilationStarted 编译开始事件
            CompilationPipeline.compilationStarted += CompilationStarted;
            // CompilationPipeline.compilationFinished 编译结束事件
            CompilationPipeline.compilationFinished += CompilationFinished;
            CompilationPipeline.assemblyCompilationFinished += AssemblyCompilationFinished;
        }
        
        private void OnDestroy()
        {
            CompilationPipeline.compilationStarted -= CompilationStarted;
            CompilationPipeline.compilationFinished -= CompilationFinished;
            CompilationPipeline.assemblyCompilationFinished -= AssemblyCompilationFinished;
            
        }
        
        private void CompilationStarted(object obj)
        {
            Debug.Log("Compilation Started");
        }
        
        private void CompilationFinished(object obj)
        {
            Debug.Log("Compilation Finished");
        }
        
        private void AssemblyCompilationFinished(string assembly, CompilerMessage[] messages)
        {
            Debug.Log("Assembly Compilation Finished");
            Debug.Log("Assembly: " + assembly);
        }
    }
}