# ARF_FaceTrackingTransceiver
iPhoneからFaceTrackingのブレンドシャイプの値と顔の回転をPCに送るためのアプリ  
Unityプロジェクトです  

Unity2019.4.14f1　 
ARfoundation4.0.8　//たぶん最新でも動くと思います  
OSCJack 1.0.3  
UniRx   
UniTask //結局つかってない  

とりあえず自作モデルが動くところまでは確認してますがやりっぱなしなので使い方はよくわからないかも  
頭回転は自作モデル用になってるので各々で調整する必要あり。  
ただ、設定しなくても動くようになってるはず  

【おおまかな使い方】  
iPhoneはSampleSceneをビルドしたものをインストールする。  
受けて側のPCは自作モデルのあるシーンにOscServer.csとOSCJackのEventReceiverをアタッチして必要な設定をする。  
OSCJackSeverシーンを参考にして下さい。  

自作モデルのブレンドシャイプはBlenderAddon「FaceIt」で作られるブレンドシャイプ名になってます。  
受け取る側のブレンドシャイプ名が違う場合はOscServer.csのDictionary作成の時に自分のモデルのブレンドシャイプ名に書きかける必要があります  

2021/9/25更新
ブレンドシェイプアニメーションを保存できるようにしました。
保存は受信したPCサーバ側で行います。
「R」キーを押すとブレンドシェイプアニメーションが録画開始。
もう一度「R]キーを押すとApplication.persistentDataPathにJsonファイルを保存します
一回送受信をやめてアプリを再起動。
その後「スペース」キーを押すと録画したアニメーションが再生されます
