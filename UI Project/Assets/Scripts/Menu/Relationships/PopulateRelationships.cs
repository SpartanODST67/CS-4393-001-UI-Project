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

    private void Start()
    {
        LoadRelationships();
    }

    public void LoadRelationships()
    {
        StartCoroutine("LoadRelationshipsCoroutine");
    }

    IEnumerator LoadRelationshipsCoroutine()
    {
        for (int i = 0; i < relationshipBank.characters.Count; i++)
        {
            GameObject button = Instantiate(buttonPrefab, gameObject.transform);
            TextMeshProUGUI text = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Button buttonScript = button.GetComponent<Button>();
            ButtonItem buttonItem = button.GetComponent<ButtonItem>();
            buttonItem.SetIndex(i);
            text.text = relationshipBank.characters[i].GetCharacterName() + ": " + relationshipBank.relationshipLevels[i].ToString();
            buttonScript.onClick.AddListener(() => {
                detailsPage.SetCharacterName(relationshipBank.characters[buttonItem.GetIndex()].GetCharacterName());
                detailsPage.SetCharacterDescription(relationshipBank.characters[buttonItem.GetIndex()].GetCharacterDescription());
                detailsPage.SetCharacterLevel(relationshipBank.relationshipLevels[buttonItem.GetIndex()]);
                detailsPage.SetProgressBar(new Vector2(relationshipBank.characters[buttonItem.GetIndex()].GetCurrentThreshold(), relationshipBank.relationshipPoints[buttonItem.GetIndex()]));
                detailsPage.SetLikeItems(relationshipBank.characters[buttonItem.GetIndex()].GetLikedItems());
                detailsPage.SetDislikeItems(relationshipBank.characters[buttonItem.GetIndex()].GetDislikedItems());
                detailsPage.Open();
            });

            yield return null;
        }
    }
}
