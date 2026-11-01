Unity 作業製作流程與操作說明 (HW4)
以下是本次 Unity 3D 飛行與障礙物作業的詳細製作流程與相關操作說明：
1. 專案截圖<img width="900" height="427" alt="image" src="https://github.com/user-attachments/assets/7bb30ccc-226b-484f-bb55-b4a394dce08e" />

 2. GitHub 連結
https://github.com/Sakuya0417/-1151VR-HW4-412262620--.git
3. YouTube 連結
https://youtu.be/8BAZ76DucGs
4. 說明製作流程和相關操作
•	3D 專案準備與模型匯入：建立 Unity 3D 專案，匯入飛行器 (Player) 與障礙物 (Obstacle) 3D 模型，並在 Scene 中佈置飛行場景。物理與碰撞設定：為飛行器加上 Rigidbody (剛體) 與 Collider (碰撞體)，並為障礙物加上 Collider。在障礙物之間的空隙處建立一個隱形的 Cube，勾選 Is Trigger，並將其 Tag 設為「ScoreZone」作為順利通過的偵測區；將障礙物的 Tag 設為「Obstacle」。
•	音效元件與腳本實作：為飛行器新增 Audio Source 元件。撰寫 C# 腳本 (FlightController)，宣告三個 AudioClip 變數接收「飛行中」、「撞擊」與「通過」音效。利用 Update() 實作持續往前飛行與點擊螢幕向上飛的控制；利用 OnCollisionEnter() 偵測撞擊並播放撞到障礙物音效；利用 OnTriggerEnter() 偵測通過 ScoreZone 並播放順利通過音效。
•	APK 輸出與手機端測試：透過 File -> Build Profiles (或 Build Settings) 將平台切換至 Android。點擊 Build 輸出 APK 檔案，安裝至手機或 Android 模擬器中，確認點擊螢幕可順利操作飛行器，且三種音效皆能正確觸發播放。
