// =============================================================
//  ViewModels.cs — Albert Gelman Inc. Sitefinity homepage
//  -------------------------------------------------------------
//  All view-model classes for the homepage partials, in one file
//  for portability. Move into one-class-per-file under
//  /ViewModels/ before merging into the .NET Core Renderer project.
//
//  Naming follows the homepage section numbering 01–07 + Header / Footer.
//  Default values match the design comp content so the page renders
//  immediately without CMS configuration. In production, replace
//  defaults with values pulled from Sitefinity dynamic modules and
//  decorate string properties with [DataMember] / [DisplayName] /
//  Sitefinity field-builder attributes as needed.
// =============================================================

using System.Collections.Generic;

namespace AlbertGelman.Web.ViewModels
{
    // ---------------------------------------------------------
    // Shared section header (3/9 asymmetric grid)
    // ---------------------------------------------------------
    public class SectionHeadViewModel
    {
        public string Number { get; set; }      // e.g. "02"
        public string Label { get; set; }       // e.g. "The Firm"
        public string TitleId { get; set; }     // e.g. "who-title"
        public string TitleHtml { get; set; }   // may contain <em>...</em>
    }

    public class LinkItem
    {
        public string Label { get; set; }
        public string Url { get; set; }
    }

    // ---------------------------------------------------------
    // Header
    // ---------------------------------------------------------
    public class HeaderViewModel
    {
        public IList<LinkItem> NavItems { get; set; } = new List<LinkItem>
        {
            new LinkItem { Label = "About Us",            Url = "#about"     },
            new LinkItem { Label = "Services",            Url = "#services"  },
            new LinkItem { Label = "Who We Serve",        Url = "#serve"     },
            new LinkItem { Label = "News & Insights",     Url = "#insights"  },
            new LinkItem { Label = "Insolvency Documents",Url = "#documents" },
            new LinkItem { Label = "Careers",             Url = "#careers"   },
            new LinkItem { Label = "Contact",             Url = "#contact"   }
        };

        public string LinkedInUrl { get; set; } = "https://linkedin.com/company/albert-gelman-inc";
        public string CtaUrl      { get; set; } = "#book";
        public string CtaLabel    { get; set; } = "Book a Discovery Call";
    }

    // ---------------------------------------------------------
    // 01 — Hero
    // ---------------------------------------------------------
    public class HeroViewModel
    {
        public string EyebrowLeftStrong  { get; set; } = "Albert Gelman Inc.";
        public string EyebrowLeftSub     { get; set; } = "Federally Licensed Insolvency Trustees";
        public string EyebrowRightStrong { get; set; } = "EST. 1985";
        public string EyebrowRightSub    { get; set; } = "Toronto · Edmonton · Vancouver";

        // Two lines. <em>...</em> renders in jade-deep italic Fraunces.
        public IList<string> HeadlineLines { get; set; } = new List<string>
        {
            "Senior Judgment.",
            "<em>Right-Sized</em> Support."
        };

        public string SupportingCopy { get; set; } =
            "AGI delivers sophisticated insolvency and restructuring solutions " +
            "through a senior-led, right-sized team — providing strategic, " +
            "pragmatic guidance aligned with your objectives, risk profile, " +
            "and commercial realities.";

        public string CtaUrl      { get; set; } = "#book";
        public string CtaLabel    { get; set; } = "Get clarity on your options";
        public string CtaFootnote { get; set; } = "Complimentary 30-minute discovery call";
    }

    // ---------------------------------------------------------
    // 02 — Who We Are
    // ---------------------------------------------------------
    public class WhoWeAreViewModel
    {
        public string PortraitMonogram { get; set; } = "AGI";
        public string PortraitLocation { get; set; } = "Bay Street · Toronto";
        public string PortraitTenure   { get; set; } = "↳ 40+ Yrs";

        public string LeadHtml { get; set; } =
            "A federally licensed insolvency and restructuring firm — " +
            "built for the moments when <em>clarity matters most.</em>";

        public IList<string> Paragraphs { get; set; } = new List<string>
        {
            "Albert Gelman Inc. serves individuals, business owners, and financial institutions across Canada. " +
            "We provide custom-tailored solutions for <strong>proposals, bankruptcies, restructurings, and " +
            "receiverships</strong> — with senior judgment at every turn.",

            "Our expertise spans both corporate and personal matters, especially where owner-operated " +
            "businesses intersect with individual financial exposure. Whether you are an individual seeking " +
            "clarity or an organization navigating economic complexity, we help you move forward with confidence."
        };

        public string MoreUrl   { get; set; } = "/about";
        public string MoreLabel { get; set; } = "More about the firm";

        public string TestimonialsLabel { get; set; } = "What partners say";
    }

    public class TestimonialViewModel
    {
        public string Quote  { get; set; }
        public string Author { get; set; }
        public string Role   { get; set; }
    }

    // ---------------------------------------------------------
    // 03 — People
    // ---------------------------------------------------------
    public class PeopleViewModel
    {
        public string Intro { get; set; } =
            "No layers, no front-line administrators. Every engagement is led by " +
            "a Licensed Insolvency Trustee with decades of experience across " +
            "corporate and personal mandates.";

        public string ScrollHint { get; set; } = "Drag or scroll to view team →";

        public IList<PersonViewModel> People { get; set; } = new List<PersonViewModel>
        {
            new() { Monogram = "AG", Credentials = "LIT · CIRP",          RoleTagSuffix = "↳ Founder",   Name = "Albert Gelman",  Title = "President, Licensed Insolvency Trustee" },
            new() { Monogram = "BG", Credentials = "LIT · Restructuring", RoleTagSuffix = "↳ Principal", Name = "Bryan Gelman",   Title = "Principal, Licensed Insolvency Trustee" },
            new() { Monogram = "JS", Credentials = "CPA · CIRP",          RoleTagSuffix = "↳ Director",  Name = "Jane Sinclair",  Title = "Director, Corporate Insolvency" },
            new() { Monogram = "MR", Credentials = "LIT · CPA",           RoleTagSuffix = "↳ Senior",    Name = "Michael Reyes",  Title = "Senior Manager, Receiverships" },
            new() { Monogram = "PN", Credentials = "BIA Estate Admin",    RoleTagSuffix = "↳ Lead",      Name = "Priya Nair",     Title = "Lead Estate Administrator" },
            new() { Monogram = "TW", Credentials = "Forensic · CPA",      RoleTagSuffix = "↳ Partner",   Name = "Thomas Wei",     Title = "Partner, Forensic & Disputes" }
        };
    }

    public class PersonViewModel
    {
        public string Monogram      { get; set; }
        public string Credentials   { get; set; }
        public string RoleTagSuffix { get; set; }
        public string Name          { get; set; }
        public string Title         { get; set; }
        public string ImageUrl      { get; set; }  // optional override of the monogram
    }

    // ---------------------------------------------------------
    // 04 — Who We Serve
    // ---------------------------------------------------------
    public class WhoWeServeViewModel
    {
        public string Intro { get; set; } =
            "We support individuals and organizations navigating financial uncertainty — " +
            "each with different priorities, pressures, and paths forward.";

        public IList<AudienceCardViewModel> Cards { get; set; } = new List<AudienceCardViewModel>
        {
            new() { Number = "01 · Personal",      TitleHtml = "Individuals &amp; <em>Self-Employed</em>",
                    Body  = "Clear, respectful guidance on proposals, bankruptcies, and tax-related debt issues — explained in plain language and delivered without judgment.",
                    LinkLabel = "Learn more about options for individuals", LinkUrl = "/services/personal" },

            new() { Number = "02 · Corporate",     TitleHtml = "Businesses, Owners &amp; <em>Executives</em>",
                    Body  = "Expert restructuring and corporate insolvency guidance designed to stabilize operations, manage stakeholder dynamics, and protect value.",
                    LinkLabel = "Explore options for businesses", LinkUrl = "/services/corporate" },

            new() { Number = "03 · Institutional", TitleHtml = "Banks &amp; <em>Lenders</em>",
                    Body  = "Court-ready receivership execution and stakeholder coordination, supported by reliable reporting from appointment through realization.",
                    LinkLabel = "Find out how we can help", LinkUrl = "/services/lenders" },

            new() { Number = "04 · Referral",      TitleHtml = "Lawyers &amp; <em>Accountants</em>",
                    Body  = "A responsive, collaborative referral partner for clients requiring licensed insolvency expertise and dependable execution.",
                    LinkLabel = "Learn how we help you and your clients", LinkUrl = "/services/referrals" },

            new() { Number = "05 · Advisory",      TitleHtml = "Dispute &amp; Stakeholder <em>Advisory</em>",
                    Body  = "Guidance for shareholder conflict, stakeholder disputes, or complex negotiations — where clarity, structure, and impartial execution are essential.",
                    LinkLabel = "Learn how we can help", LinkUrl = "/services/advisory" }
        };
    }

    public class AudienceCardViewModel
    {
        public string Number    { get; set; }
        public string TitleHtml { get; set; }
        public string Body      { get; set; }
        public string LinkLabel { get; set; }
        public string LinkUrl   { get; set; }
    }

    // ---------------------------------------------------------
    // 05 — Facts
    // ---------------------------------------------------------
    public class FactsViewModel
    {
        public IList<FactViewModel> Facts { get; set; } = new List<FactViewModel>
        {
            new() { NumericTarget = "40",   DisplayNumber = "40",   Unit = "+ yrs", Meta = "EST. 1985",
                    LabelHtml = "<strong>Continuous practice</strong> serving Canadian businesses, lenders, and families across four decades." },

            new() { NumericTarget = "3",    DisplayNumber = "3",    Meta = "Coast to Coast",
                    LabelHtml = "<strong>Provinces covered</strong> — Ontario, Alberta, and British Columbia — with senior trustees on the ground." },

            new() { NumericTarget = "50",   DisplayNumber = "$50",  Unit = "M", Meta = "File Threshold",
                    LabelHtml = "<strong>Trusted referral partner</strong> for Bay Street firms and lenders on files up to $50 million." },

            new() { NumericTarget = "2500", DisplayNumber = "2,500",Unit = "+", Meta = "Mandates Completed",
                    LabelHtml = "<strong>Corporate &amp; personal engagements</strong> administered — from consumer proposals to complex multi-jurisdictional receiverships." },

            new() { NumericTarget = "0",    DisplayNumber = "0",    Unit = "%", Meta = "Senior Turnover",
                    LabelHtml = "Same trustees, same standard — every year." },

            new() { NumericTarget = "24",   DisplayNumber = "24",   Unit = "h", Meta = "Response Standard",
                    LabelHtml = "<strong>Direct senior contact</strong> on new inquiries from lenders and referring counsel within one business day." },

            new() { NumericTarget = "100",  DisplayNumber = "100",  Superscript = "%", Meta = "LIT-Led",
                    LabelHtml = "Every file is overseen by a Licensed Insolvency Trustee from intake through closing." }
        };
    }

    public class FactViewModel
    {
        public string NumericTarget { get; set; }   // GSAP counter target (no $ or commas)
        public string DisplayNumber { get; set; }   // initial render text (may include $)
        public string Unit          { get; set; }   // small italic jade suffix
        public string Superscript   { get; set; }   // alt to Unit for very small marks (e.g. %)
        public string Meta          { get; set; }   // mono eyebrow above label
        public string LabelHtml     { get; set; }   // descriptive sentence
    }

    // ---------------------------------------------------------
    // 06 — How We Help
    // ---------------------------------------------------------
    public class HowWeHelpViewModel
    {
        public string IntroTitleHtml { get; set; } =
            "An advisory practice built around " +
            "<em style=\"font-style:italic; color:var(--color-jade-deep);\">measured action.</em>";

        public string IntroBody { get; set; } =
            "Each engagement is matched to the realities of the file — its complexity, " +
            "risk profile, and the parties involved. The result is sharper recommendations, " +
            "fewer surprises, and decisions made with confidence.";

        public IList<ServiceViewModel> Services { get; set; } = new List<ServiceViewModel>
        {
            new() { Number = "A · 01", Title = "Corporate Restructuring",
                    Body = "CCAA proposals, NOI filings, and operational restructurings designed to preserve enterprise value and stakeholder confidence.",
                    LinkUrl = "/services/corporate-restructuring" },

            new() { Number = "A · 02", Title = "Receiverships",
                    Body = "Court-appointed and private receiverships — disciplined execution from appointment through asset realization and distribution.",
                    LinkUrl = "/services/receiverships" },

            new() { Number = "A · 03", Title = "Corporate Bankruptcy",
                    Body = "Orderly wind-downs and BIA proceedings managed with precision, transparency, and clear creditor communication.",
                    LinkUrl = "/services/corporate-bankruptcy" },

            new() { Number = "B · 04", Title = "Consumer Proposals",
                    Body = "A path to debt resolution that protects assets and credit recovery prospects — built around your circumstances.",
                    LinkUrl = "/services/consumer-proposals" },

            new() { Number = "B · 05", Title = "Personal Bankruptcy",
                    Body = "A non-judgmental, plainly-explained process — focused on the fresh start and what comes after it.",
                    LinkUrl = "/services/personal-bankruptcy" },

            new() { Number = "C · 06", Title = "Forensic &amp; Disputes",
                    Body = "Forensic accounting, stakeholder dispute resolution, and impartial court-related mandates for complex matters.",
                    LinkUrl = "/services/forensic-disputes" }
        };

        public string CtaTagline { get; set; } = "A practice tailored to the file — not the firm’s convenience.";
        public string CtaUrl     { get; set; } = "/services";
        public string CtaLabel   { get; set; } = "Explore our full range of services";
    }

    public class ServiceViewModel
    {
        public string Number  { get; set; }
        public string Title   { get; set; }
        public string Body    { get; set; }
        public string LinkUrl { get; set; }
    }

    // ---------------------------------------------------------
    // 07 — Why Albert Gelman Inc.?
    // ---------------------------------------------------------
    public class WhyAGIViewModel
    {
        public string Statement { get; set; } =
            "Clients choose us for more than technical expertise — they choose us for " +
            "<em>direct access, clear recommendations,</em> and a team that stays " +
            "engaged from start to finish.";

        public IList<string> Points { get; set; } = new List<string>
        {
            "Direct, responsive access to licensed insolvency professionals.",
            "Proportional execution aligned to complexity, risk, and cost sensitivity.",
            "Depth across consumer and corporate mandates, including owner-operator complexity.",
            "Clear recommendations and decisive next steps.",
            "Professional, respectful service grounded in dignity and clarity.",
            "A disciplined process and reliable reporting for stakeholder matters and receiverships."
        };

        public string SecondaryCtaLabel { get; set; } = "Learn what sets us apart";
        public string SecondaryCtaUrl   { get; set; } = "/about";
        public string PrimaryCtaLabel   { get; set; } = "Book a complimentary discovery call";
        public string PrimaryCtaUrl     { get; set; } = "#book";
    }

    // ---------------------------------------------------------
    // Footer
    // ---------------------------------------------------------
    public class FooterViewModel
    {
        public string LogoSrc { get; set; } = "/ResourcePackages/AlbertGelman/assets/AG_Logo_rgb.webp";

        public string CtaCardHeadline { get; set; } = "Speak directly with a Licensed Insolvency Trustee.";
        public string CtaCardLabel    { get; set; } = "Book a complimentary call";
        public string CtaCardUrl      { get; set; } = "#book";

        public IList<OfficeViewModel> Offices { get; set; } = new List<OfficeViewModel>
        {
            new() { City = "Toronto", Tag = "Head Office",
                    AddressHtml = "150 Ferrand Dr., Suite 1503<br/>Toronto, Ontario M3C 3E5",
                    Phone = "+1 855 654 1650", Email = "info@albertgelman.com" },

            new() { City = "Edmonton",
                    AddressHtml = "200 – 16011 116 Ave NW<br/>Edmonton, AB T5M 3Y1" },

            new() { City = "Vancouver",
                    AddressHtml = "1168 Hamilton St. #502<br/>Vancouver, BC V6B 2S2" }
        };

        public IList<FooterColumnViewModel> NavColumns { get; set; } = new List<FooterColumnViewModel>
        {
            new() { Heading = "About",
                    Links = new List<LinkItem> {
                        new() { Label = "The Firm",          Url = "/about" },
                        new() { Label = "Our People",        Url = "/people" },
                        new() { Label = "Careers",           Url = "/careers" },
                        new() { Label = "News & Insights",   Url = "/insights" }
                    } },

            new() { Heading = "Services",
                    Links = new List<LinkItem> {
                        new() { Label = "Corporate Restructuring", Url = "/services/corporate-restructuring" },
                        new() { Label = "Receiverships",           Url = "/services/receiverships" },
                        new() { Label = "Consumer Proposals",      Url = "/services/consumer-proposals" },
                        new() { Label = "Personal Bankruptcy",     Url = "/services/personal-bankruptcy" },
                        new() { Label = "Forensic & Disputes",     Url = "/services/forensic-disputes" }
                    } },

            new() { Heading = "Resources",
                    Links = new List<LinkItem> {
                        new() { Label = "Insolvency Documents", Url = "/documents" },
                        new() { Label = "Client Portal",        Url = "/portal" },
                        new() { Label = "Referral Partners",    Url = "/referrals" },
                        new() { Label = "Contact",              Url = "/contact" }
                    } }
        };

        public IList<LinkItem> LegalLinks { get; set; } = new List<LinkItem>
        {
            new() { Label = "Privacy Policy", Url = "/privacy" },
            new() { Label = "Terms of Use",   Url = "/terms" },
            new() { Label = "Accessibility",  Url = "/accessibility" }
        };

        public string LinkedInUrl    { get; set; } = "https://linkedin.com/company/albert-gelman-inc";
        public int    CopyrightStart { get; set; } = 1985;
    }

    public class OfficeViewModel
    {
        public string City        { get; set; }
        public string Tag         { get; set; }  // e.g. "Head Office"
        public string AddressHtml { get; set; }
        public string Phone       { get; set; }
        public string Email       { get; set; }
    }

    public class FooterColumnViewModel
    {
        public string Heading { get; set; }
        public IList<LinkItem> Links { get; set; } = new List<LinkItem>();
    }
}
