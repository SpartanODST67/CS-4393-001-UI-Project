using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateRelationships : MonoBehaviour
{
    [SerializeField] RelationshipBank relationshipBank;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] DetailsManager detailsPage;

    private void OnEnable()
    {
        LoadRelationships();
    }

    public void LoadRelationships()
    {
        StartCoroutine("LoadRelationshipsCoroutine");
    }

    IEnumerator LoadRelationshipsCoroutine()
    {
        for(int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
            yield return null;
        }

        for (int i = 0; i < relationshipBank.characters.Count; i++)
        {
            GameObject button = Instantiate(buttonPrefab, gameObject.transform);
            TextMeshProUGUI text = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Button buttonScript = button.GetComponent<Button>();
            ButtonItem buttonItem = button.GetComponent<ButtonItem>();
            buttonItem.SetIndex(i);
            text.text = WriteText(text, i);
            buttonScript.onClick.AddListener(() =>
            {
                detailsPage.SetCharacterName(relationshipBank.characters[buttonItem.GetIndex()].GetCharacterName());
                detailsPage.SetCharacterDescription(relationshipBank.characters[buttonItem.GetIndex()].GetCharacterDescription());
                detailsPage.SetCharacterLevel(relationshipBank.relationshipLevels[buttonItem.GetIndex()], relationshipBank.characters[buttonItem.GetIndex()].GetMaxLevels());
                detailsPage.SetProgressBar(new Vector2(relationshipBank.characters[buttonItem.GetIndex()].GetCurrentThreshold(), relationshipBank.relationshipPoints[buttonItem.GetIndex()]));
                detailsPage.Open();
                detailsPage.SetLikeItems(relationshipBank.characters[buttonItem.GetIndex()].GetLikedItems());
                detailsPage.SetDislikeItems(relationshipBank.characters[buttonItem.GetIndex()].GetDislikedItems());
            });

            yield return null;
        }
    }

    private string WriteText(TextMeshProUGUI text, int i)
    {
        if (relationshipBank.relationshipLevels[i] >= relationshipBank.characters[i].GetMaxLevels())
        {
            return relationshipBank.characters[i].GetCharacterName() + ": MAX";
        }
        return relationshipBank.characters[i].GetCharacterName() + ": " + relationshipBank.relationshipLevels[i].ToString();
    }
}
