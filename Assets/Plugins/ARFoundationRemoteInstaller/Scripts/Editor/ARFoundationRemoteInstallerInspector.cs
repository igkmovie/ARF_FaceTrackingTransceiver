#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;


namespace ARFoundationRemote.Editor {
    [CustomEditor(typeof(ARFoundationRemoteInstaller), true), CanEditMultipleObjects]
    public class ARFoundationRemoteInstallerInspector : UnityEditor.Editor {
        bool isARFoundationEmbedded;
        
        
        void OnEnable() {
            isARFoundationEmbedded = ARFoundationRemoteInstaller.getArf()?.source == PackageSource.Embedded;
            var instance = (ARFoundationRemoteInstaller) target;
            if (isARFoundationEmbedded && !instance.installerSettings.IsUninstalling) {
                #if AR_FOUNDATION_REMOTE_INSTALLED
                FixesForEditorSupport.Apply();
                #endif
            }
        }

        public override void OnInspectorGUI() {
            if (EditorApplication.isCompiling) {
                return;
            }
            
            DrawDefaultInspector();
            showMethodsInInspector(targets);
        }

        void showMethodsInInspector(params Object[] inspectorTargets) {
            GUILayout.Space(8);
            var instance = inspectorTargets.First() as ARFoundationRemoteInstaller;
            Assert.IsNotNull(instance);

            if (isInstalled) {
                if (isARFoundationEmbedded) {
                    GUILayout.Space(16);
                    GUILayout.Label("AR Companion app", EditorStyles.boldLabel);
                    var boldButtonStyle = new GUIStyle(GUI.skin.button) {fontStyle = FontStyle.Bold};
                    if (GUILayout.Button("Install AR Companion App", boldButtonStyle)) {
                        execute(CompanionAppInstaller.BuildAndRun);
                    }

                    if (GUILayout.Button("Build AR Companion and show in folder", new GUIStyle(GUI.skin.button))) {
                        execute(CompanionAppInstaller.Build);
                    }

                    if (GUILayout.Button("Delete AR Companion app build folder")) {
                        execute(CompanionAppInstaller.DeleteCompanionAppBuildFolder);
                    }

                    GUILayout.Space(8);
                    if (GUILayout.Button("Open Settings", boldButtonStyle)) {
                        #if AR_FOUNDATION_REMOTE_INSTALLED
                        SettingsService.OpenProjectSettings($"Project/XR Plug-in Management/{Runtime.Constants.packageName}");
                        #endif
                    }

                    GUILayout.Space(16);
                    /*if (GUILayout.Button("Apply AR Foundation fixes")) {
                        AutoARFoundationFixes.Enabled = true;
                        #if AR_FOUNDATION_REMOTE_INSTALLED
                            FixesForEditorSupport.Apply();
                        #endif
                    }*/

                    /*if (GUILayout.Button("Undo AR Foundation fixes")) {
                        AutoARFoundationFixes.Enabled = false;
                        #if AR_FOUNDATION_REMOTE_INSTALLED
                        FixesForEditorSupport.Undo();
                        #endif
                    }*/
                } else {
                    if (GUILayout.Button("Embed AR Foundation Package")) {
                        ARFoundationRemoteInstaller.EmbedARFoundation();
                    }        
                }
            
                GUILayout.Space(16);
                GUILayout.Label("Plugin", EditorStyles.boldLabel);
                if (GUILayout.Button("Un-install Plugin", new GUIStyle(GUI.skin.button) {normal = {textColor = Color.red}})) {
                    instance.UnInstallPlugin();
                }
            } else {
                if (GUILayout.Button("Install Plugin")) {
                    instance.InstallPlugin();
                }
            }
            
            if (isARFoundationEmbedded && GUILayout.Button("Un-embed AR Foundation")) {
                ARFoundationRemoteInstaller.UnEmbedARFoundation();
            }

            drawVersionUpgrade();
            /*if (GUILayout.Button("DEBUG")) {
            }*/
        }

        static void drawVersionUpgrade() {
            #if AR_FOUNDATION_REMOTE_2_0_OR_NEWER
            return;
            #endif

            #pragma warning disable 162
            GUILayout.Space(32);
            GUILayout.Label("New version available!", EditorStyles.boldLabel);
            GUILayout.Space(8);

            GUILayout.Label("Want even more awesome features?\n" +
                            "Upgrade to <b>AR Foundation Remote 2.0</b> with a <color=#E24747><b>discount</b></color>.", 
                new GUIStyle {wordWrap = true, richText = true, margin = new RectOffset(4, 4, 4, 4)});
            GUILayout.Space(8);
            if (GUILayout.Button("View on Asset Store", GUI.skin.button)) {
                Application.OpenURL("https://assetstore.unity.com/packages/slug/201106");
            }
            #pragma warning restore 162
        }

        static bool isInstalled {
            get {
                return
                #if AR_FOUNDATION_REMOTE_INSTALLED
                    true;
                #else
                    false;
                #endif
            }
        }
        
        static void execute(Action action) {
            action();
        }
    }
}
#endif // UNITY_EDITOR
