﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace AdaptiveCards
{
    /// <summary>
    ///     Container for a collection of elements
    /// </summary>
    public class Container : CardElement
    {
        public Container()
        {
            Type = "Container";
        }

        /// <summary>
        ///     Elements of the container
        /// </summary>
        [JsonRequired]
#if NET45
        [XmlElement(typeof(TextBlock))]
        [XmlElement(typeof(Image))]
        [XmlElement(typeof(Container))]
        [XmlElement(typeof(ColumnSet))]
        [XmlElement(typeof(FactSet))]
        [XmlElement(typeof(ImageSet))]
        [XmlElement(typeof(InputText), ElementName ="Input.Text")]
        [XmlElement(typeof(InputDate), ElementName ="Input.Date")]
        [XmlElement(typeof(InputTime), ElementName = "Input.Time")]
        [XmlElement(typeof(InputNumber), ElementName = "Input.Number")]
        [XmlElement(typeof(InputToggle), ElementName = "Input.Toggle")]
        [XmlElement(typeof(InputChoiceSet), ElementName = "Input.ChoiceSet")]
#endif
        public List<CardElement> Items { get; set; } = new List<CardElement>();

        /// <summary>
        ///     Action for this container (this allows a default action at the container level)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ActionBase SelectAction { get; set; }

        /// <summary>
        ///     Actions for this container
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
#if NET45
        [XmlArray("Actions")]
        [XmlArrayItem(ElementName = "Action.OpenUrl", Type = typeof(ActionOpenUrl))]
        [XmlArrayItem(ElementName = "Action.ShowCard", Type = typeof(ActionShowCard))]
        [XmlArrayItem(ElementName = "Action.Submit", Type = typeof(ActionSubmit))]
        [XmlArrayItem(ElementName = "Action.Http", Type = typeof(ActionHttp))]
#endif
        public List<ActionBase> Actions { get; set; } = new List<ActionBase>();


        public bool ShouldSerializeActions()
        {
            return Actions.Any();
        }
    }
}