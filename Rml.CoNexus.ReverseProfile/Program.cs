using Rml.CoNexus.ReverseProfile;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Rml.CoNexus.ReverseProfile;

internal class Program
{
    static void Main(string[] args)
    {
        CC.Header("CoNexus Reverse Profile Generator", "0.0.0");
        Axis weightsAxis = new Axis()
        {
            Method = VoteMethod.PAIRS,
            Role = AxisRole.WEIGHTS,    // there will be only one WEIGHTS
            Label = "Importance",
            AxisScale = new Scale(
                scaleName: "Forced Choice, 3-point scale",
                entries: new List<ScaleEntry>
                {
                    { new ScaleEntry() { Value = 3, SelectionKey = ConsoleKey.NumPad9, InBottomScaleGroup = false, Text = "9 = large difference, 3 points" } },
                    { new ScaleEntry() { Value = 2, SelectionKey = ConsoleKey.NumPad8, InBottomScaleGroup = false, Text = "8 = moderate difference, 2 points" } },
                    { new ScaleEntry() { Value = 1, SelectionKey = ConsoleKey.NumPad7, InBottomScaleGroup = false, Text = "7 = large difference, 1 points" } },
                    { new ScaleEntry(isPlaceholder: true) },
                    { new ScaleEntry() { Value = 1, SelectionKey = ConsoleKey.NumPad1, InBottomScaleGroup = true, Text = "9 = large difference, 1 points" } },
                    { new ScaleEntry() { Value = 2, SelectionKey = ConsoleKey.NumPad2, InBottomScaleGroup = true, Text = "9 = large difference, 2 points" } },
                    { new ScaleEntry() { Value = 3, SelectionKey = ConsoleKey.NumPad3, InBottomScaleGroup = true, Text = "9 = large difference, 3 points" } }
                }
            )
        };

        // for all Alternatives
        Axis contributionAxis = new Axis()
        {
            Method = VoteMethod.CONTRIBUTION,
            Role = AxisRole.ALTERNATIVE,
            Label = "Contribution",
            AxisScale = new Scale(
                scaleName: "Rating, continuous 1-9",
                entries: new List<ScaleEntry>
                {
                    { new ScaleEntry() { Value = 9, SelectionKey = ConsoleKey.NumPad9, InBottomScaleGroup = false, Text = "9 = practically perfect" }},
                    { new ScaleEntry() { Value = 8, SelectionKey = ConsoleKey.NumPad8, InBottomScaleGroup = false, Text = "8 = excellent" }},
                    { new ScaleEntry() { Value = 7, SelectionKey = ConsoleKey.NumPad7, InBottomScaleGroup = false, Text = "7 = very good" } },
                    { new ScaleEntry() { Value = 6, SelectionKey = ConsoleKey.NumPad6, InBottomScaleGroup = true, Text = "6 = good" } },
                    { new ScaleEntry() { Value = 5, SelectionKey = ConsoleKey.NumPad5, InBottomScaleGroup = true, Text = "5 = average" } },
                    { new ScaleEntry() { Value = 4, SelectionKey = ConsoleKey.NumPad4, InBottomScaleGroup = true, Text = "4 = under average" } },
                    { new ScaleEntry() { Value = 3, SelectionKey = ConsoleKey.NumPad3, InBottomScaleGroup = true, Text = "3 = poor" } },
                    { new ScaleEntry() { Value = 2, SelectionKey = ConsoleKey.NumPad2, InBottomScaleGroup = true, Text = "2 = very poor" } },
                    { new ScaleEntry() { Value = 1, SelectionKey = ConsoleKey.NumPad1, InBottomScaleGroup = true, Text = "1 = none" } }
                }
            )
        };

        // for "Current" Alternative only
        Axis historyAxis = new Axis()
        {
            Method = VoteMethod.RATE,
            Role = AxisRole.CURRENT,
            Label = "History",
            AxisScale = new Scale(
                scaleName: "Rating, continuous 1-2",
                entries: new List<ScaleEntry>
                {
                    { new ScaleEntry() { Value = 2, SelectionKey = ConsoleKey.O, InBottomScaleGroup = false, Text = "2 = feature present currently" }},
                    { new ScaleEntry() { Value = 1, SelectionKey = ConsoleKey.NumPad8, InBottomScaleGroup = false, Text = "1 = new requirement" }},
                }
            )
        };

        Cost money = new Cost()
        {
            Value = 0,
            Text = "$US",
            Multiplier = 1000.0m,
            Comment = "Acquisition cost"
        };

        Cost time = new Cost()
        {
            Value = 0,
            Text = "minutes",
            SimulationValueRange = (12, 90),
            Comment = "Commuting time"
        };

        Alternatives alts = new(
            [
                new Alternative() {
                    Symbol = "A",
                    Text =  "Current",
                    XAxes = [contributionAxis, historyAxis],
                    Costs = [money, time]
                },
                new Alternative() {
                    Symbol = "B",
                    Text =  "8080 Processor Way",
                    XAxes = [contributionAxis],
                    Costs = [money, time]
                },
                new Alternative() {
                    Symbol = "C",
                    Text =  "5055 Chesterfield",
                    XAxes = [contributionAxis],
                    Costs = [money, time]
                },
                new Alternative() {
                    Symbol = "D",
                    Text =  "8080 Processor Way",
                    XAxes = [contributionAxis],
                    Costs = [money, time]
                },
                new Alternative() {
                    Symbol = "E",
                    Text =  "1701 Starburst Court",
                    XAxes = [contributionAxis],
                    Costs = [money, time]
                }
            ]);

        Criteria crits = new(
            [
                new Criterion() {Symbol = "1", Text = "Natural light" },
                new Criterion() {Symbol = "2", Text = "Views of Nature" },
                new Criterion() {Symbol = "3", Text = "AC Power" },
                new Criterion() {Symbol = "4", Text = "Quiet Office" },
                new Criterion() {Symbol = "5", Text = "Outside Door" },
                new Criterion() {Symbol = "6", Text = "Sink and Bathroom" },
                new Criterion() {Symbol = "7", Text = "Patio" },
            ]);

        Demographics demQ = new(
        [
            new DemographicQuestion("What department do you work in?",
                new Choices(
                    [
                        new Choice() { Value = 1, ChoiceKey = ConsoleKey.NumPad1, Text = "Engineering" },
                        new Choice() { Value = 2, ChoiceKey = ConsoleKey.NumPad2, Text = "Marketing" },
                        new Choice() { Value = 3, ChoiceKey = ConsoleKey.NumPad3, Text = "Sales" },
                        new Choice() { Value = 4, ChoiceKey = ConsoleKey.NumPad4, Text = "Admin" },
                        new Choice() { Value = 5, ChoiceKey = ConsoleKey.NumPad5, Text = "Leadership" }
                    ]
                )
            ),
            new DemographicQuestion("How long have you been with the company?",
                new Choices(
                    [
                        new Choice() { Value = 1, ChoiceKey = ConsoleKey.NumPad1, Text = "First year" },
                        new Choice() { Value = 2, ChoiceKey = ConsoleKey.NumPad2, Text = "2-5 years" },
                        new Choice() { Value = 3, ChoiceKey = ConsoleKey.NumPad3, Text = "6-10 years" },
                        new Choice() { Value = 4, ChoiceKey = ConsoleKey.NumPad4, Text = "10+ years" },
                    ]
                )
            )
        ]
    );
    }

    // =====================================================
    public class InputTemplate
    {
        public InputTemplate(string title, string inqId, string[] evalIds)
        {
            Title = title;
            InquiryId = inqId;
            Array.Copy(evalIds, EvaluationIds, evalIds.Length);
        }

        public string InquiryId { get; set; }
        public string[] EvaluationIds { get; set; } = []; // one/Profile, more when comparing
        public ProfileType ProfileType { get; set; } = ProfileType.GROUP;

        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public ParticipantGroup? Participants { get; set; } // Participants contain their vote collections, Y-axis goes to Inquiry
        public Demographics? Demographics { get; set; }
        public Axis? Weights { get; set; }       // Weights are available to all results calculations
        public Alternatives? Alts { get; set; }  // Alts contain Costs, Contribution, and any additional X axes 
        public Criteria? Crits { get; set; }
    }
    public enum ProfileType
    {
        GROUP,
        CONSENSUS,
        INDIVIDUAL
    };
    public class ProfileDto  // Output
    {
        public ProfileDto(InputTemplate inp, Axis xaxis)
        {
            InquiryId = inp.InquiryId;
            Title = inp.Title;
            ProfileType = inp.ProfileType;
            XLabel = xaxis.Label;
            YLabel = inp.Weights.Label;
            ParticipantIds = inp.Participants.Select(x => x.Id).ToArray();
        }
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string InquiryId { get; set; }
        public string[] EvaluationIds { get; set; } // one/Profile, more when comparing
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? XLabel { get; set; }
        public string? YLabel { get; set; }
        public ProfileType ProfileType { get; set; } = ProfileType.GROUP;
        public IEnumerable<ProfileItemDto> Items { get; set; }

        public string[] ParticipantIds { get; set; } = [];
        public string[] Participants { get; set; } = [];
        public string[] TopicIds { get; set; } = [];
        public string[] Topics { get; set; } = [];
        public string[] ChoiceIds { get; set; } = [];
        public string[] Choices { get; set; } = [];
    }
    public class ProfileItemDto
    {
        public ProfileItemDto() { }

        public string? Symbol { get; set; }
        public string? Text { get; set; }
        public string? ToolTip { get; set; }
        public int DisplayGroup { get; set; } // used when comparing Profiles
        public bool DisplayOnly { get; set; } // marker only, not movable, does not participate in interpretation
        public bool Hidden { get; set; }
        public decimal X { get; set; } = -1;
        public decimal Y { get; set; } = -1;
    }

    #region Topic stuff
    public class Topic
    {
        public Topic() { }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string? Text { get; set; }

        /* Topic:
         *      string Id;
         *      string Text;
         */
    }
    public class Choice : Topic
    {
        /* Topic:
         *      string Id;
         *      string Text;
         */

        public ConsoleKey ChoiceKey { get; set; } = ConsoleKey.None;
        public decimal Value { get; set; }

        /* Topic:
         *      string Id;
         *      string Text;
         * Choice:
         *      ConsoleKey ChoiceKey;
         *      decimal Value;
         */
    }
    public class Choices : List<Choice>
    {
        public Choices(IEnumerable<Choice> items)
        {
            base.AddRange(items);
        }
    }
    public interface ISimRange
    {
        (decimal lowest, decimal highest) SimulationValueRange { get; set; }
    }

    public class Cost : Topic, ISimRange
    {
        public Cost() { }

        public Cost(decimal defaultValue, string units, decimal costWeight) { }

        /* Topic:
         *      string Id;
         *      string Text;
         */
        public decimal Value { get; set; }
        public decimal Weight { get; set; } = 1.0m;
        public decimal Multiplier { get; set; } = 1.0m;
        public string? Comment { get; set; }

        // for simulation:
        public (decimal lowest, decimal highest) SimulationValueRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /* Topic:
         *      string Id;
         *      string Text;
         * Cost:
         *      decimal Value;
         *      decimal Weight;
         *      decimal Multiplier;
         *      string Comment;
         */
    }
    public class Criterion : Topic
    {
        public Criterion() { }
        public Criterion(string symbol, string? comment)
        {
            Symbol = symbol;
            Comment = comment;
        }

        /* Topic:
         *      string Id;
         *      string Text;
         */

        public string? Symbol { get; set; }

        public string? Comment { get; set; }

        /* Topic:
         *      string Id;
         *      string Text;
         * Criterion:
         *      string? Symbol;
         *      string? Comment;
         */
    }
    public class Alternative : Topic
    {
        public Alternative() { }
        public Alternative(string symbol, string? comment, IEnumerable<Axis> axes, IEnumerable<Cost> costs)
        {
            Symbol = symbol;
            Comment = comment;
            XAxes.AddRange(axes);
            Costs.AddRange(costs);
        }

        /* Topic:
         *      string Id;
         *      string Text;
         */

        public string? Symbol { get; set; }

        public List<Axis> XAxes { get; set; } = [];
        public int XAxisCount => XAxes.Count();

        public List<Cost> Costs { get; set; } = [];
        public int CostCount => Costs.Count();

        public string? Comment { get; set; }

        /* Topic:
         *      string Id;
         *      string Text;
         * Alternative:
         *      string? Symbol;
         *      IEnumerable<Axis> XAxes;
         *      IEnumerable<Cost> Costs;
         *      string? Comment;
         */
    }
    public class Alternatives : List<Alternative>
    {
        public Alternatives() { }
        public Alternatives(IEnumerable<Alternative> items)
        {
            base.AddRange(items);
        }

        public Alternative? this[string id] => base.Find(x => x.Id.Equals(id));
        // base allows this[int index]
    }
    public class Criteria : List<Criterion>
    {
        public Criteria() { }
        public Criteria(IEnumerable<Criterion> items)
        {
            base.AddRange(items);
        }

        public Criterion? this[string id] => base.Find(x => x.Id.Equals(id));
        // base allows this[int index]
    }
    #endregion
    #region Scale & Demographics stuff
    public class ScaleEntry : Topic
    {
        /* Topic:
         *      string Id;
         *      string Text;
         */

        public ScaleEntry() { }
        public ScaleEntry(bool isPlaceholder)
        {
            SelectionKey = ConsoleKey.None;
            IsPlaceholder = isPlaceholder;
        }

        public ConsoleKey SelectionKey { get; set; }
        public decimal Value { get; set; }
        public bool IsPlaceholder { get; set; }
        public bool InBottomScaleGroup { get; set; }

        /* Topic:
         *      string Id;
         *      string Text;
         * ScaleEntry:
         *      ConsoleKey SelectionKey;
         *      decimal Value;
         *      bool IsPlaceholder;
         *      bool InBottomScaleGroup;
         */
    }
    public class Scale : List<ScaleEntry>
    {
        public Scale() { }
        public Scale(string scaleName, IEnumerable<ScaleEntry> entries)
        {
            this.AddRange(entries);
            LegalKeys = entries.Select(x => x.SelectionKey).ToArray();
            ChoiceIds = entries.Select(x => x.Id).ToArray();
            ChoiceText = entries.Select(x => x.Text!).ToArray();
        }

        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public VoteMethod Method { get; private set; }
        public string? Name { get; private set; }
        public ConsoleKey[] LegalKeys { get; private set; }
        public string[] ChoiceIds { get; private set; }
        public string[] ChoiceText { get; private set; }
    }
    #endregion
    #region Axis stuff
    public class Axis
    {
        public Axis() { }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string? AlternativeId { get; set; }      // set when Role is not WEIGHTS

        [Required]
        [StringLength(50)]
        public string? Label { get; set; }

        public string? AxisId { get; set; }
        public string? Question { get; set; }
        public VoteMethod Method { get; set; } = VoteMethod.UNSPECIFIED;
        public AxisRole Role { get; set; } = AxisRole.UNKNOWN;
        public Scale? AxisScale { get; set; }

        public bool IsEmpty => Method is VoteMethod.UNSPECIFIED;
    }
    public class Axes : List<Axis> 
    {
        public Axes() { }
        public Axes(IEnumerable<Axis> items)
        {
            base.AddRange(items);
        }

        public Axis? this[string id] => base.Find(x=>x.Id.Equals(id));
    }
    #endregion
    #region Evaluation
    // Sends votes to the screen and returns with choice
    public class EvaluationDto
    {
        public EvaluationDto(Axis axis, Participant part, Alternative alt, Criterion crit)
        {
            Question = axis.Question ?? "error";
            ParticipantId = part.Id;
            TopTopic = crit.Text ?? throw new InvalidDataException("Evaluation cannot procedure when Criterion text is null.");
            if (axis.AxisScale is null) throw new InvalidDataException("Evaluation cannot procedure when Axis scale is null.");
            LegalKeys = axis.AxisScale.LegalKeys;
            ChoiceIds = axis.AxisScale.ChoiceIds;
            ChoiceText = axis.AxisScale.ChoiceText;
        }

        public string Question { get; set; }
        public string ParticipantId { get; set; }
        public string TopTopic { get; set; }
        public string? BottomTopic { get; set; }
        public ConsoleKey[] LegalKeys { get; set; }
        public string[] ChoiceIds { get; set; }
        public string[] ChoiceText { get; set; }
    }
    #endregion
    #region Votes
    public enum VoteMethod : byte
    {
        UNKNOWN = 0,
        RATE,
        PAIRS,
        DIRECT,
        MULCH,
        CONTRIBUTION
    };
    public enum AxisRole : byte
    {
        UNKNOWN = 0,
        WEIGHTS,        // uses PAIRS & crits to develop weights/crit @ inq level
        COSTS,          // uses DIRECT & CostSpecs to capture costs... directly
        CURRENT,        // X-axis data
        ALTERNATIVE     // X-axis data
    };
    public class Vote
    {
        public Vote(Axis axis, Participant part, Criterion top, Criterion bottom)
        {
            AxisId = axis.Id;
            ParticipantId = part.Id;

            SelectedTopicId = top.Id;
            ComparedTopicId = bottom.Id;
        }

        public Vote(Axis axis, Participant part, Alternative alt, Criterion crit)
        {
            AxisId = axis.Id;
            ParticipantId = part.Id;

            AlternativeId = alt.Id;
            SelectedTopicId = crit.Id;
        }

        public bool Voted { get; set; }

        public string? AxisId { get; set; }
        public string? ParticipantId { get; set; }

        public string? AlternativeId { get; set; }
        public string? SelectedTopicId { get; set; }
        public string? ComparedTopicId { get; set; }

        public Choice? SelectedChoice { get; set; }

        public decimal Raw { get; set; }
        public decimal Scaled { get; set; }
        public decimal Weighted { get; set; }

        private (string selId, string? cmpId) SwapTopics(Topic selected)
        {
            string selectedTopicId = SelectedTopicId ?? "";
            if (SelectedTopicId == selected.Id) return (selectedTopicId, ComparedTopicId);
            string? temp = ComparedTopicId;
            ComparedTopicId = selectedTopicId;
            SelectedTopicId = temp;
            return (selectedTopicId, ComparedTopicId);
        }

        public override string ToString() => $"On Axis #{AxisId}, for Topics #{SelectedTopicId} and #{ComparedTopicId}: user #{ParticipantId}{votedOrNot()} ";
        private string votedOrNot() => Voted
            ? $"selected Choice #{SelectedChoice!.Id} - Raw={Raw:N0}, Weighted={Weighted:N2} "
            : $"waiting to vote";
    }
    public class Votes : List<Vote> 
    { 
    }
    public class DemographicQuestion
    {
        public DemographicQuestion() { }
        public DemographicQuestion(string question, IEnumerable<Choice> choices)
        {
            Question = question;
            Choices = choices;
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string? Question { get; set; }
        public IEnumerable<Choice> Choices { get; set; } = Enumerable.Empty<Choice>();
        public int Count => Choices.Count();
    }
    public class Demographics : List<DemographicQuestion>
    {
        public Demographics(IEnumerable<DemographicQuestion> questions)
        {
            base.AddRange(questions);
        }

        public DemographicQuestion? this[string id]=> base.Find(x=>x.Id.Equals(id));
    }
    #endregion
    #region Profile stuff
    public class Profile : List<ProfilePoint>
    {
        private List<ProfilePoint> _pts = new();
        private List<ProfileAxis> _axes = new();

        public Profile() { }
        public Profile(Axes axes)
        {
            foreach (Axis axis in axes)
            {
                ProfileAxis pa = new(axis);
            }
        }

        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public IEnumerable<ProfilePoint> Points => _pts;
        public IEnumerable<ProfileAxis> Axes => _axes;
    }
    public class ProfileAxis
    {
        /// <summary>
        /// Holds the voted values for a single axis. They are keyed to a combination of Axis.Id,
        /// Participant.Id, and Topic.Id.
        /// </summary>
        private Dictionary<string, double> _axisValues = new();

        public ProfileAxis() { }
        public ProfileAxis(Axis axis, Votes votes)
        {
            AxisId = axis.Id;
            Role = axis.Role;
            Label = axis.Label;
            AxisScale = axis.AxisScale;

            foreach ()
    }

        public string? AxisId { get; set; }
        public AxisRole Role { get; set; }
        public string? Label { get; set; }
        public Scale? AxisScale { get; set; }

        public void AddVote(Axis axis, Participant part, Votes votes)
        {

        }
    }
    public class ProfilePoint   // works for group Profile, individuals, consensus
    {
        private Rectangle _canvas = new(0, 0, 1000, 1000);  // locations are integers, 0 to 100

        public ProfilePoint(Rectangle plane)
        {
            _canvas = plane;
        }

        // Location
        public double X { get; set; }   // 0-100
        public double Y { get; set; }   // 0-100
        public string? Symbol { get; set; }
        public bool IsAnonymous { get; set; }   // set when the Symbol should not be revealed
        public bool IsIndicator { get; set; }   // set when point is a visual placeholder only
        public bool ChangedFlag { get; set; }   // set when point is moved 'cause collided
        public string? Text { get; set; }
    }
    public class ProfileTopicPoint
    {
        private Rectangle _prf = new(0, 0, 1000, 1000);  // locations are integers, 0 to 100

        // Location
        public double X { get; set; }   // 0-100
        public double Y { get; set; }   // 0-100
        public string? Symbol { get; set; }
        public bool ChangedFlag { get; set; }   // set when point is moved 'cause collided
        public string? Text { get; set; }
    }
    #endregion
    #region People stuff
    public class ParticipantGroup : List<Participant>
    {
        public ParticipantGroup() { }

        public ParticipantGroup(IEnumerable<Participant> people) => base.AddRange(people);

        public Participant? this[string id] => base.Find(x => x.Id.Equals(id));
        // base allows this[int index]
    }
    public class Participant
    {
        public Participant()
        {
            InquiryId = "error";
            Name = "";
            Email = "";
        }

        public Participant(string inqId, string name, string email)
        {
            InquiryId = inqId;
            Name = name;
            Email = email;
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string InquiryId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        /* Participant:
         *      string Id;
         *      string InquiryId;
         *      string Name;
         *      string Email;
         */
    }
    #endregion
}
