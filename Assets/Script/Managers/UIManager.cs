using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private Dictionary<UIType, UIElement> m_UIList = new Dictionary<UIType, UIElement>() ;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowUI(UIType typeToShow)
    {
        if(GetUI(typeToShow) != null)
        {
            GetUI(typeToShow).Show();
        }
    }

    private void Initialize()
    {
        for(int i = 0; i < transform.childCount -1; i++)
        {
            UIElement newUIElement = transform.GetChild(i).GetComponent<UIElement>();

            if (newUIElement != null)
            {
                m_UIList.Add(newUIElement.AssociateType, newUIElement);
            }
        }
    }

    public UIElement GetUI(UIType uiToGet)
    {
        UIElement targetElement = null;

        m_UIList.TryGetValue(uiToGet, out targetElement);

        return targetElement;
    }
}
