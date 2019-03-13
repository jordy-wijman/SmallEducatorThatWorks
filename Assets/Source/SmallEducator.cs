using System.Collections;
using System.Collections.Generic;
using Source.Composite;
using Source.GUI;
using Source.LeafBehaviour;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;
using Component = Source.Composite.Component;

namespace Source
{
    public class SmallEducator : MonoBehaviour
    {
        private readonly List<Component> activeComponents = new List<Component>();
        public Image backgroundTextFieldOne;
        public Image backgroundTextFieldTwo;

        private MonoBehaviour currentQuestionnaire;
        private bool done;

        private OnlineResourceBehaviour extraResource;
        public Button extraResourceButton;
        private Component head;
        private bool isQuestionnaireActive;
        private IEnumerator<Component> iterator;

        public MultipleChoiceQuestionnaire multipleChoiceQuestionnaire;
        public GameObject quad;
        private readonly List<Component> removeComponents = new List<Component>();

        public TextMeshProUGUI textFieldOne;
        public TextMeshProUGUI textFieldTwo;

        public TextInit textInit;
        private float timer;

        public VideoPlayer videoPlayer;

        private void Reset()
        {
            Init();
        }

        private void Awake()
        {
            Init();
        }

        // Use this for initialization
        private void Start()
        {
            Init();
        }

        private void AddLeafWithText(Component head, float minute, float second, ILeafBehaviour behaviour)
        {
            Component textLeaf = new SmallEducatorLeaf(1001, "TextLeaf", minute, second, this, behaviour);
            head.AddComponent(textLeaf);
        }

        private TextTyper SetTextTyper(TextMeshProUGUI textField)
        {
            var textTyper = textField.GetComponent<TextTyper>();
            textTyper.TextField = textField;
            textTyper.TextSetting = new List<TextInit>();
            textTyper.TextSetting.Add(textInit);
            return textTyper;
        }

        private void Init()
        {
            UnityEngine.GUI.backgroundColor = Color.blue;
            head = new SmallEducatorComposite(0, "Head", -1.0f);

            TextTyper textTyper = null;
            textFieldOne = GameObject.FindGameObjectWithTag("TextFieldOne").GetComponent<TextMeshProUGUI>();
            textFieldTwo = GameObject.FindGameObjectWithTag("TextFieldTwo").GetComponent<TextMeshProUGUI>();
            backgroundTextFieldOne = GameObject.FindGameObjectWithTag("BackgroundTextFieldOne").GetComponent<Image>();
            backgroundTextFieldTwo = GameObject.FindGameObjectWithTag("BackgroundTextFieldTwo").GetComponent<Image>();
            extraResourceButton = GameObject.FindGameObjectWithTag("ExtraResourceButton").GetComponent<Button>();
            textTyper = SetTextTyper(textFieldOne);
            textTyper = SetTextTyper(textFieldTwo);

            LoadWeek2()
                ;
            //API test 
            //StartCoroutine(GetText());

            /*/Video
ILeafBehaviour textBehaviour = new VideoBehaviour(videoPlayer,
    "/Users/mjgth/Videos/Dm1hrYJX0AA8b5V.mp4"
    , false,
    //"https://video.twimg.com/tweet_video/DG8HO7UW0AAzsrL.mp4"
    //, true, 
    new Vector2(0, 0), 1024, 1024, quad);
//VideoBehaviour(, new Vector2(0, 0), 400.0f, 400.0f);
*/

            /*
        listOfLines.Clear();
        listOfLines.Add("hahaha ha hahahaha hahaha ha");
        listOfLines.Add("bla bla bla bla");
        listOfLines.Add("lalala lala lalalala lalala");

        //Typed text
        textBehaviour = new TextBehaviour(textTyper, listOfLines, new Vector2(-100, 100));
        addLeafWithText(head, 0.0f, 11.0f, textBehaviour);

        //ImageBehaviour(SmallEducator smallEducator, string url, GameObject quad,
        //Vector2 position, Texture2D tex, float timer)
        Texture2D tex = new Texture2D(680, 577, TextureFormat.DXT1, false);
        textBehaviour = new ImageBehaviour(this, "https://www.uml-diagrams.org/class-diagrams/class-diagram-domain-overview.png", quad, new Vector2(0, 0), tex, 10.0f);
        addLeafWithText(head, 0.0f, 11.0f, textBehaviour);
        */
            iterator = head.GetIterator();
            timer = 0.0f;
            done = false;
        }

        
        private void AddMultipleChoiceQuestionnaire(float positionOnTimeLine)
        {
            var anwsers = new List<string>();
            anwsers.Add("Yes");
            anwsers.Add("No");
            anwsers.Add("No..");

            anwsers.Add("Yes\nddddddddddddddddddddddsfsfsdf\ndfgdgdg");
            anwsers.Add("Yes\nddddddddddddddddddddddsfsfsdf\ndfgdgdg");
            anwsers.Add("No\nqwert\njyghf");
            anwsers.Add("No\nqwert\njyghf");

            var question =
                "Is dit een hele lange vraag om te beantwoorden zodat we de \ntextfield kunnen testen?\nYes it does!!";
            var singleAnswer = false;

            addMultipleChoiceQuestionnaire(positionOnTimeLine + 1.0f, anwsers, question, singleAnswer);
        }

        private void addMultipleChoiceQuestionnaire(float positionOnTimeLine, List<string> anwsers, string question,
            bool singleAnswer)
        {
            ILeafBehaviour choiceResource =
                new MultipleChoiceBehaviour(multipleChoiceQuestionnaire, anwsers, question, singleAnswer);
            AddLeafWithText(head, Mathf.Floor(positionOnTimeLine / 60.0f), positionOnTimeLine % 60.0f, choiceResource);
        }

        private float setStaticTextBehaviour(TextMeshProUGUI textField, Image backgroundTextField,
            List<string> listOfLines,
            ExtraTextSettings extraTextSettings, float timeOnScreen, float positionOnTimeLineSeconds, Vector2 position)
        {
            //Static text
            ILeafBehaviour textBehaviour = new StaticTextBehaviour(listOfLines, textField,
                backgroundTextField, extraTextSettings,
                timeOnScreen, position);
            AddLeafWithText(head, Mathf.Floor(positionOnTimeLineSeconds / 60.0f), positionOnTimeLineSeconds % 60.0f,
                textBehaviour);
            positionOnTimeLineSeconds += timeOnScreen + 0.30f;

            return positionOnTimeLineSeconds;
        }

        private float SetStaticTextBehaviour(TextMeshProUGUI textField, Image backgroundTextField,
            List<string> listOfLines,
            ExtraTextSettings extraTextSettings, float timeOnScreen, float positionOnTimeLineSeconds)
        {
            //Static text
            ILeafBehaviour textBehaviour = new StaticTextBehaviour(listOfLines, textField,
                backgroundTextField, extraTextSettings,
                timeOnScreen, new Vector2(0, -38));
            AddLeafWithText(head, Mathf.Floor(positionOnTimeLineSeconds / 60.0f), positionOnTimeLineSeconds % 60.0f,
                textBehaviour);
            positionOnTimeLineSeconds += timeOnScreen + 0.30f;

            return positionOnTimeLineSeconds;
        }

        public void RemoveComponent(Component componentToRemove)
        {
            removeComponents.Add(componentToRemove);
        }

        // Update is called once per frame
        public void FixedUpdate()
        {
            CleanUpActiveComponents();

            if (!isQuestionnaireActive)
            {
                CheckForNewActiveComponent();
                Play();
            }
        }

        private void CheckForNewActiveComponent()
        {
            //Debug.Log("Current.TimeStamp: " + iterator.Current.TimeStamp + " timer: " + timer);

            if (!done && iterator.Current.TimeStamp <= timer)
            {
                iterator.Current.Start();
                activeComponents.Add(iterator.Current);
                done = !iterator.MoveNext();
            }
        }

        private void Play()
        {
            foreach (var component in activeComponents) component.DoAction();
            timer += Time.fixedDeltaTime;
        }

        private void CleanUpActiveComponents()
        {
            if (removeComponents.Count > 0)
            {
                foreach (var component in removeComponents) activeComponents.Remove(component);
                removeComponents.Clear();
            }
        }

        public void QuestionnaireStarted(MonoBehaviour questionnaire)
        {
            currentQuestionnaire = questionnaire;
            isQuestionnaireActive = true;
        }

        public void QuestionnaireFinished()
        {
            currentQuestionnaire = null;
            isQuestionnaireActive = false;
        }

        public void ExtraResourceOnClick()
        {
            if (extraResource != null) extraResource.DoOnClick();
        }

        public void QuestionOnClick()
        {
            Debug.Log("Prompt the question box!!");
        }
        IEnumerator GetText()
        {
            UnityWebRequest www = UnityWebRequest.Get("http://www.my-server.com");
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }
}