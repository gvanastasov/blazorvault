using BlazorVault.Enums;

namespace BlazorVault.Constants
{
	internal static class Modifiers
	{
		internal const string Separator = "-";
		
		internal static class Common
		{
			internal const string Horizontal = "horizontal";
			internal const string Flush = "flush";
			internal const string Body = "body";
			internal const string Item = "item";
			internal const string Active = "active";
			internal const string Disabled = "disabled";
			internal const string Group = "group";
			internal const string Label = "label";
			internal const string Current = "current";
			internal const string Toolbar = "toolbar";
			internal const string Vertical = "vertical";
			internal const string List = "list";

			internal const string Btn = "btn";
			
			internal static string BtnGroup
			{
				get
				{
					return string.Concat(Btn, Separator, Group);
				}
			}

			internal static string BtnGroupVertical
			{
				get
				{
					return string.Concat(BtnGroup, Separator, Vertical);
				}
			}

			internal static string BtnToolbar
			{
				get
				{
					return string.Concat(Btn, Separator, Toolbar);
				}
			}
		}

		internal static class Layouts
		{
			internal const string Container = "container";
			internal const string ContainerFluid = "container-fluid";
			internal const string ScrollableCode = "pre-scrollable";
			internal const string Row = "row";
			internal const string Column = "col";
			internal const string ColumnGeneric = "col-{0}";
			internal const string JustificationGeneric = "justify-content-{0}";
			internal const string NoGutters = "no-gutters";
			internal const string WGeneric = "w-{0}";

			internal static string W100
			{
				get
				{
					return string.Format(WGeneric, 100);
				}
			}
		}

		internal static class Typographies
		{
			internal const string Heading = "h{0}";
			internal const string Display = "display-{0}";
			internal const string Lead = "lead";
		}

		internal static class Elements
		{
			internal const string Alert = "alert";
			internal const string AlertGeneric = "alert-{0}";
			internal const string Badge = "badge";
			internal const string BadgeGeneric = "badge-{0}";
			internal const string BadgePill = "badge-pill";
			internal const string Breadcrumb = "breadcrumb";
			internal const string BreadcrumbItem = "breadcrumb-item";
			internal const string Card = "card";

			internal static string ListGroup
			{
				get
				{
					return string.Concat(Common.List, Separator, Common.Group);
				}
			}

			internal static string ListGroupFlush
			{
				get
				{
					return string.Concat(ListGroup, Separator, Common.Flush);
				}
			}

			internal static string ListGroupHorizontal
			{
				get
				{
					return string.Concat(ListGroup, Separator, Common.Horizontal);
				}
			}

			internal static string ListGroupItem
			{
				get
				{
					return string.Concat(ListGroup, Separator, Common.Item);
				}
			}

			internal static string CardBody
			{
				get
				{
					return string.Concat(Card, Separator, Common.Body);
				}
			}

			internal static string CardGeneric
			{
				get
				{
					return $"{Card}{Separator}{{0}}";
				}
			}

		}
	}
}
