Game Navigation Script
======================

## Simple Navigation Script

```
 public void ChangeScene(string SceneToLoad)
        {
            //Changes scene to the specified scene
            SceneManager.LoadSceneAsync(SceneToLoad);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
```

This simple function allows us to change scene dependent on what string we feed in.