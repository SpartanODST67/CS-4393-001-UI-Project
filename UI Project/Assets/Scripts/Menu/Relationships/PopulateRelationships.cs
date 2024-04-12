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
            ButtonIndex buttonIndex = button.GetComponent<ButtonIndex>();
            buttonIndex.SetIndex(i);
            text.text = WriteText(i);
            buttonScript.onClick.AddListener(() =>
            {
                detailsPage.SetCharacterName(relationshipBank.characters[buttonIndex.GetIndex()].GetCharacterName());
                detailsPage.SetCharacterDescription(relationshipBank.characters[buttonIndex.GetIndex()].GetCharacterDescription());
                detailsPage.SetCharacterLevel(relationshipBank.relationshipLevels[buttonIndex.GetIndex()], relationshipBank.characters[buttonIndex.GetIndex()].GetMaxLevels());
                detailsPage.SetProgressBar(new Vector3(relationshipBank.characters[buttonIndex.GetIndex()].GetSpecificThreshold(relationshipBank.relationshipLevels[buttonIndex.GetIndex()]), relationshipBank.characters[buttonIndex.GetIndex()].GetSpecificThreshold(relationshipBank.relationshipLevels[buttonIndex.GetIndex()] - 1), relationshipBank.relationshipPoints[buttonIndex.GetIndex()]));
                detailsPage.Open();
                detailsPage.SetLikeItems(relationshipBank.characters[buttonIndex.GetIndex()].GetLikedItems());
                detailsPage.SetDislikeItems(relationshipBank.characters[buttonIndex.GetIndex()].GetDislikedItems());
            });

            yield return null;
        }
    }

    private string WriteText(int i)
    {
        if (relationshipBank.relationshipLevels[i] >= relationshipBank.characters[i].GetMaxLevels())
        {
            return relationshipBank.characters[i].GetCharacterName() + ": MAX";
        }
        return relationshipBank.characters[i].GetCharacterName() + ": " + relationshipBank.relationshipLevels[i].ToString();
    }
}
