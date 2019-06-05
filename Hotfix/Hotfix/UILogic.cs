namespace Hotfix
{
    public class UILogic
    {
        public UILogic(BaseUI ui)
        {
            ui.btn.onClick.AddListener(() => 
            {
                ui.text.text = "Click Button!";
                ui.img.color = UnityEngine.Color.red;
            });
        }
    }
}
