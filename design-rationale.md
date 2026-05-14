# Albert Gelman Inc. — Homepage Design Rationale
**Designer + Developer ready guidance · v1.0 · Cubicle Fugitive**

---

## Creative Director's Note

> 🎨 **CREATIVE DIRECTION** — *Editorial Tension × Swiss Restraint*
> 💡 **CONCEPT** — A boutique advisory firm should read as a *publication* a Bay Street partner trusts, not a corporate brochure. Magazine architecture (oversized serif, asymmetric grid, mono eyebrows, deep whitespace) signals calibre instantly; restrained motion and warm cream washes keep the firm human, not clinical.
> 🔤 **TYPOGRAPHY** — Fraunces (variable serif with optical-size and *SOFT* axes — Google) for display; Inter Tight (Google) for body; JetBrains Mono (Google) for eyebrows and metadata. *Adobe upgrade path: Freight Display Pro + Acumin Pro — drop-in swap via Typekit.*
> 🎨 **COLOR STORY** — Deep navy as authority, brand green as the only chromatic accent in flow, warm cream and pale mint as section washes that warm the firm without softening credibility. Amber gold reserved exclusively for awards and recognitions, never decoration.
> ⚡ **MOTION INTENT** — One philosophy: *content arrives once, with intent.* Rule lines draw in, headline words mask-rise, numbers count once, and parallax is reserved for the AG mark only. No effects-for-effects-sake. Respects `prefers-reduced-motion` everywhere.
> 🔌 **INTEGRATION HOOKS** — GSAP 3 + ScrollTrigger for staged reveals · Alpine.js for testimonial slider, header state, scroll cue · Iconify (ph:) for icons · Sitefinity media library for portraits, video placeholders for People section if upgraded later.

---

## 1. Strategic Premise

The AGI homepage must do three things at once, in the first 6 seconds:

1. **Signal calibre** to a Bay Street partner or a TD Bank lender — *"this firm is in the right tier."*
2. **Reassure** an owner-operator under stress — *"these people are senior, calm, and human."*
3. **Recruit** a senior associate eyeing a move from a national firm — *"this is a real practice, not a debt clinic."*

Every visual decision below is graded against those three audiences simultaneously. Where the design feels too cold for the owner-operator, we warm with cream; where it feels too soft for the lender, we tighten the grid and let the serif do the work.

The aesthetic precedents the brief points to — *bartoszkolenda.com*, *akfaholding.com*, *namiercapital.com*, *santai-space.webflow.io* — all share the same underlying logic: **typography as architecture, asymmetric composition, surgical use of accent color.** That logic is the spine of this design.

---

## 2. Design System Tokens

All tokens defined in CSS-first config (Tailwind v4 `@theme` directive). No `tailwind.config.js`.

### 2.1 Color Palette

| Token | OKLCH | Approx HEX | Role | Usage Ratio |
|---|---|---|---|---|
| `--color-ink` | `oklch(18% 0.05 264)` | `#0A1A3D` | Primary navy — text, headers, dark sections | 30% |
| `--color-ink-soft` | `oklch(26% 0.055 264)` | `#172749` | Softened navy — secondary surfaces | — |
| `--color-jade` | `oklch(56% 0.16 148)` | `#1F9F58` | Brand green — only chromatic accent in flow | 10% |
| `--color-jade-deep` | `oklch(46% 0.15 148)` | `#187B43` | Green hover / italic accents | — |
| `--color-amber` | `oklch(82% 0.16 88)` | `#FFC200` | Reserved for awards & recognitions only | <2% |
| `--color-paper` | `oklch(98.5% 0.004 80)` | `#FDFCFA` | Default page background — warm off-white | 60% |
| `--color-cream` | `oklch(96.5% 0.016 82)` | `#F7F2E8` | Section wash — humanity (Who We Are, hover) | — |
| `--color-mint` | `oklch(96% 0.022 152)` | `#EAF5EC` | Section wash — distinctiveness (Facts) | — |
| `--color-fog` | `oklch(93% 0.008 240)` | `#E5E8EE` | Cool fog — minor surfaces | — |
| `--color-ash` | `oklch(88% 0.006 240)` | `#D7DAE0` | Hairline rules | — |

**Ratio rule:** Paper or cream dominates 60% of any view; navy carries 30%; jade green is the 10% accent. Amber gold appears in <2% of total surface — only on awards.

### 2.2 Typography

| Token | Family | Role |
|---|---|---|
| `--font-display` | `Fraunces` (variable) | Headlines, section titles, large numerals |
| `--font-body` | `Inter Tight` | All body, UI, captions |
| `--font-mono` | `JetBrains Mono` | Eyebrows, metadata, section numbers |

**Fraunces axes used:** `opsz` (optical size) from 9–144, `SOFT` from 0–100, weight from 300–500. The `SOFT` axis is the key — at low `opsz` and `SOFT 30` it reads as a precise serif; at high `opsz` and `SOFT 70+` it gets the ink-trap warmth of premium magazine serifs. Italics use `SOFT 70` for the editorial swing.

**Fluid scale:** All sizes use `clamp()` to scale from 320px to 1440px viewport. No fixed sizes anywhere.

| Token | Mobile | Desktop |
|---|---|---|
| `--text-hero` | 3.5rem | 9.5rem |
| `--text-display` | 3rem | 6.5rem |
| `--text-4xl` | 2.5rem | 5rem |
| `--text-3xl` | 2rem | 3.5rem |
| `--text-2xl` | 1.625rem | 2.25rem |
| `--text-xl` | 1.25rem | 1.625rem |
| `--text-lg` | 1.0625rem | 1.25rem |
| `--text-base` | 0.9375rem | 1.0625rem |

**Type pairing logic:**
- **Display + mono eyebrow** is the editorial signal — magazine credit-line meets cover headline.
- **Italic Fraunces with `SOFT 70`** in the brand green is the firm's *signature voice* — used sparingly inside otherwise-restrained headlines (e.g. *"Right-Sized"*, *"we are"*, *"executives"*). It's the one ornament that recurs as a brand fingerprint.

### 2.3 Grid & Spacing

The page operates on a **12-column container** at max-width 88rem (≈1408px), with fluid container padding `clamp(1.25rem, 4vw, 3.5rem)`.

**Asymmetric ratios used (the anti-50/50 rule):**
- Hero: `8 / 4` (headline / side rail)
- Section heads: `3 / 9` (number meta / title)
- Who We Are body: `5 / 7` (portrait / copy)
- People intro: `3 / 9`
- Who We Serve grid: `7 / 5` row 1, then `4 / 4 / 4` row 2
- Facts: arbitrary 12-col placements with negative-space breaks (`1/5`, `8/4`, `1/4`, etc.)
- How We Help: `7 / 5` title block, then `4 / 4 / 4` services
- Why AGI: `6 / 6` (statement / expectations list)
- Footer: `5 / 7` top, then `1 / 1 / 1` nested

**Section rhythm (vertical spacing):**
- `--section-y`: `clamp(5rem, 9vw, 10rem)` — standard
- `--section-y-lg`: `clamp(7rem, 12vw, 14rem)` — Why AGI closer

**Spatial logic:** every section opens with a hairline `border-top` and a `3/9` `section-head` (number left, serif title right). This is the **page's editorial signature** — a publication's section dividers. It gives wayfinding without ever needing a "Section 2 of 8" UI element.

---

## 3. Section-by-Section Direction

### 3.1 Header — Sticky, Minimal, Premium Institution

**Structure:** Three-column grid: `[logo+wordmark] [primary nav] [utility + CTA]`.

**Behavior:**
- Above-fold: transparent over the cream hero — header floats.
- After 24px scroll: `is-scrolled` class adds frosted-paper background (`rgba(254, 253, 250, 0.94)` + `backdrop-filter: blur(14px)`), hairline bottom rule, and tightens vertical padding from 1.25rem to 0.85rem. This compression is a **subtle calibre signal** — premium sites tighten on scroll, not loosen.

**Logo block:** AG triangle mark (32px) + Fraunces 500 wordmark "Albert Gelman" + mono micro-caption "Insolvency & Restructuring". The mono caption is removable for tighter widths but is a strong recognition mark on desktop — it tells you what the firm does without needing a tagline.

**Nav:** 7 items, animated hairline underline on hover (expanding from center). No dropdowns at the top level — this homepage is the front door; sub-nav lives on the destination pages.

**Utility:** search icon, LinkedIn icon, prominent **Book a Discovery Call** pill. The pill is the only persistent CTA and inverts on hover. Per brief, booking must remain accessible — it is the most reachable element on every screen.

**Mobile:** primary nav collapses below 900px to a future hamburger; utility CTA persists.

---

### 3.2 Hero — *Senior Judgment. Right-Sized Support.*

**Headline:** Hero Option 1 from the brief. Set in Fraunces variable display, three line-blocks each masked. On load:
1. Eyebrow row (mono) fades in at t=0.
2. Hairline rule draws left-to-right (1.6s, expo-out) at t=0.3s.
3. Headline lines mask-rise one at a time at t=0.6 / 0.75 / 0.9s (300ms stagger).
4. Side rail (body + CTA + microcopy) rises softly at t=1.1s.
5. Scroll cue pulses in at t=2s.

The italic *"Right-Sized"* in jade-deep is the brand signature. It's the only chromatic moment in the hero — it earns its color by being the firm's positioning in one word.

**Layout:** `8/4` asymmetric. Headline takes the left 8 columns (left-aligned, full bleed up to the inner gutter), side rail occupies the right 4 (bottom-aligned to share the baseline with the headline's last line — an editorial alignment trick).

**Background graphic:** The AG triangle mark, scaled to ~55vw, positioned bleeding off the right edge at 6% opacity, with a gentle 8s float animation and ScrollTrigger parallax (-60px translate over the hero scroll). It's *recognizable but never assertive* — the architecture of the icon does the talking.

**Imagery direction (production):** Hero is intentionally **type-only** with the AG mark as the sole graphic. This is the boldest move in the design. Most insolvency firm sites lead with stock photography of handshakes or worried families — both of which the brief explicitly forbids. By leading with restraint and confidence in typography, AGI's hero immediately distances itself from "consumer-debt-clinic-adjacent" presentation.

**Optional production upgrade:** a subtle dot-grain or paper-texture overlay can be added at 4-6% opacity for tactile depth. Provided as a CSS-only treatment in the production CSS file; no asset dependency.

---

### 3.3 Who We Are + Testimonials

**Section wash:** Paper white background (default). The next section (People) goes dark navy — so this section *stays light* to maximize that later contrast.

**Layout — `5/7` asymmetric:**
- **Left (5 cols):** A 4:5 aspect portrait card. Production swap: editorial portrait of Albert or Bryan Gelman — black-and-white or duotone treatment. In this mockup, the portrait is a **placeholder treatment** — gradient navy-to-ink-soft + faint horizontal line texture + giant "AGI" monogram in faded display serif top-right + mono meta tag bottom ("Bay Street · Toronto · 40+ Yrs"). This treatment is *itself a designed component* the firm can ship if production photography is delayed.
- **Right (7 cols):**
  - Lead statement in Fraunces 2xl — italic *"clarity matters most"* in jade-deep.
  - Two body paragraphs (the brief's "Who We Are" copy).
  - "More about the firm" link with arrow.

**Testimonials block (below):**
- `3/9` grid: mono label "What partners say" + active index counter on the left; quote + attribution + nav buttons on the right.
- Massive opening curly quote in jade-deep, set off-baseline to the left of the first word.
- Quote in Fraunces 2xl italic.
- Three rotating testimonials, 8s auto-advance, manual prev/next nav. Alpine handles state. Crossfade transition.
- **Production note:** populate with real attributed quotes from referring partners (Chaitons, TGF, SZK), lenders, and one institutional client. Anonymize when needed ("Senior Partner · Bay Street Law Firm") — anonymized attribution from prestigious organizations reads more credibly than named small-firm quotes.

---

### 3.4 People — Horizontal Editorial Rail

**Section wash:** Deep navy (`--color-ink`). This is the **visual breaker** of the page — coming after warm cream, the navy section punches the eye and resets attention. Light text, jade accents.

**Header:** `3/9` section head — number `03` left, serif `Senior access. From the first call.` right.

**Sub-intro:** "No layers, no front-line administrators..." — reinforces the boutique-senior-access differentiator.

**Rail:**
- Horizontal scrolling row of person cards, each `clamp(280px, 28vw, 380px)` wide.
- Cards bleed past container edge on both sides (negative margin trick: `padding-inline: var(--container-x); margin-inline: calc(var(--container-x) * -1);`) — this creates the **off-page anticipation** that says *"there's more to the right."*
- Scroll-snap-align: start. Native scroll, thin styled scrollbar. No scroll-jacking; respects user input.
- Drag cue at bottom-right: thin jade rule + mono "Drag or scroll to view team →"

**Person card composition:**
- 4:5 portrait area with subtle duotone gradient (alternating ink+200 hue and ink+264 hue cards for rhythm)
- Faint serif monogram top-left (initials, low opacity)
- Mono role tag bottom (e.g., `LIT · CIRP   ↳ Founder`)
- Below card: serif name in Fraunces xl, role line in Inter Tight sm

**Production:** swap the gradient placeholder for **editorial black-and-white portraits** — confident, calm, slightly off-axis (not corporate-headshot-frontal). Photographer brief: think *Monocle* or *Stripe Press* — natural light, environmental detail, sitter looking just-off-camera.

**Number of people:** mockup shows 6. Real list could be 8–12; rail handles unlimited.

---

### 3.5 Who We Serve — Asymmetric Audience Cards

**Section wash:** Paper white again (deliberate rhythm: light → dark → light → mint → light → dark = breathing pattern).

**Layout:** 12-column grid, 5 cards in an asymmetric `7+5 / 4+4+4` arrangement.

```
┌─────────────────────┬───────────────┐
│  01 Individuals     │  02 Businesses│
│  (7 cols)           │  (5 cols)     │
├──────────┬──────────┴────┬──────────┤
│ 03 Banks │ 04 Lawyers     │ 05 Disp.│
│ (4)      │ (4)            │ (4)     │
└──────────┴────────────────┴──────────┘
```

This rhythm — wide-then-narrow / equal-thirds — gives the section **layout interest without losing scanability.** It also lets the two highest-revenue audiences (Individuals → consumer leads; Businesses → corporate referrals) take more screen weight on top.

**Card composition:**
- Bottom-left: mono number + audience family ("`01 · Personal`", "`02 · Corporate`")
- Serif title with italic accent word in jade-deep (`Individuals & Self-Employed`)
- Body copy (brief's revised audience descriptions)
- `link-arrow` CTA at bottom, expanding gap on hover

**Hover interaction:** Each card has a `::before` cream overlay that slides up from below over 700ms (expo-out). The card "warms" as you approach — *literal* warmth metaphor, very on-brand.

**Mobile (<1000px):** collapses to 6/6 then single column under 640px.

---

### 3.6 Facts — Pale Mint, Oversized Editorial Numerals

**Section wash:** Pale mint (`--color-mint`). This is the page's **identity moment** — distinctive in the insolvency/advisory space where everyone uses blue and white. The brief specifically calls for mint and cream as section washes; this section uses mint to anchor that decision.

**Headline:** `A boutique with institutional reach.` — italic "institutional" in jade-deep.

**Composition:** Asymmetric placement on a 12-col grid with deliberate negative-space breaks. Numbers appear in `--text-display` Fraunces (6.5rem desktop) with mini superscript units (`+`, `%`, `M`, `+yrs`) in jade-deep at 35–40% scale. Mono meta tags above each fact ("EST. 1985", "Coast to Coast", "File Threshold"). Body copy below: 1–2 lines max.

**Animation:** Each number counts up once when scrolled into view (GSAP, 1.6s expo-out). Number animation triggers via ScrollTrigger and never repeats — counters feel like *facts being established*, not animations on loop.

**Facts (3 existing + 4 suggested):**

| # | Number | Label | Source |
|---|---|---|---|
| 1 | **40+ yrs** | EST. 1985 — Continuous practice | Existing |
| 2 | **3 provinces** | ON · AB · BC | Existing |
| 3 | **$50M** | File threshold for referral work | Existing |
| 4 | **2,500+** | Mandates completed (corporate + personal) | **New** |
| 5 | **0%** | Senior turnover | **New** — directly supports recruitment goal |
| 6 | **24h** | Senior response on inquiries | **New** — supports lender confidence |
| 7 | **100%** | LIT-led — every file | **New** — answers "boutique with senior access" claim |

**Production note:** Numbers 4, 5, 6, 7 are *suggestions*; the firm should confirm or refine. Number 5 ("0% senior turnover") is the recruiting hook — verify with HR before launch. Number 7 ("100% LIT-led") is a strong differentiator vs. national firms where files often pass through estate administrators.

---

### 3.7 How We Help — Type as Architecture

**Section wash:** Paper white.

**Title block — `7/5`:**
- Left 7: a massive `06` numeral in Fraunces (clamp 8–16rem) with a tiny mono "How We Help" label tucked into its top-right corner. This is *type as wayfinding* — the number IS the section divider, no separate header needed.
- Right 5: an italicized supporting subtitle ("An advisory practice built around *measured action*") and a paragraph intro.

**Service grid — 12 cols / 3 columns of cards:**
- 6 service cards in a 3×2 grid (`4 / 4 / 4`)
- Each card: mono code (`A · 01`, `B · 04`, `C · 06`) — the letter prefix indicates **practice area**: A = Corporate, B = Personal, C = Specialty
- Serif title (Fraunces xl)
- 1-line body
- Mono "Learn more →" link
- **Hairline rules between columns** drawn via `::after` pseudo-elements — gives the page a magazine grid feel without heavy borders

**Closing CTA row:**
- Italic serif statement on the left ("A practice tailored to the file — not the firm's convenience.")
- Outlined `Explore our full range of services` button on the right
- This pattern (serif statement + outlined CTA) is a **reusable corporate close** — used again in Why AGI and in the footer card

**Services listed (6):**
1. Corporate Restructuring (CCAA, NOI, operational)
2. Receiverships (court-appointed, private)
3. Corporate Bankruptcy (BIA proceedings)
4. Consumer Proposals
5. Personal Bankruptcy
6. Forensic & Disputes

Aligns with the brief's positioning statement and the firm's actual practice areas.

---

### 3.8 Why Albert Gelman Inc? — Closing Brand Statement

**Section wash:** Deep navy (`--color-ink`) — the page closes on the brand's defining color. This mirrors the People section's wash, creating a navy-cream rhythm bookending the corporate sections.

**Decorative element:** A 50vw AG triangle, navy-on-navy with jade fill at 18% opacity, bleeds from the top-right corner. It's the **echo** of the hero's bleeding triangle — the page opens and closes with the mark.

**Statement (Fraunces 3xl italic):**
> "Clients choose us for more than technical expertise — they choose us for *direct access, clear recommendations,* and a team that stays engaged from start to finish."

**Expectations list — `6/6`:**
Left 6: the statement.
Right 6: a numbered list (01 — 06) of *what you can expect* — the brief's "What you can expect" content. Each row separated by a thin rule, mono number on the left, body text on the right. Reads like a typeset publication index — calm, certain, no marketing fluff.

**Closing CTAs:**
- Outlined "Learn what sets us apart" (drives to Why AGI sub-page)
- Filled jade-green "Book a complimentary discovery call" — **the primary conversion goal**, given green-on-navy maximum visibility

---

### 3.9 Footer — Structured Closing

**Section wash:** Even deeper navy (`oklch(12% 0.04 264)`) — sits one step darker than Why AGI for a *settling* feel.

**Top region — `5/7`:**
- Left 5: AG full logo (reverse-treatment via CSS filter) + a featured CTA card ("Speak directly with a Licensed Insolvency Trustee" → Book a complimentary call).
- Right 7: Three office addresses (Toronto Head Office, Edmonton, Vancouver) + below, a 3-column nav (About / Services / Resources).

**Office cards:** Mono jade heading with parenthetical role tag (`Toronto  Head Office`), then address, phone, email. Toronto gets phone + email; satellites get address only.

**Footer nav:** Three columns mirroring the firm's information architecture.

**Bottom strip:** Copyright + legal links + LinkedIn icon, all in JetBrains Mono microcopy.

---

## 4. Motion & Interaction Philosophy

### Animation principles
1. **Content arrives once, with intent.** No repeating animations on scroll, no auto-playing loops except the hero mark's slow float.
2. **Rule lines draw, headlines mask-rise, numbers count.** Three move-types — that's it. Variety creates noise; restraint creates rhythm.
3. **Easing:** `cubic-bezier(0.16, 1, 0.3, 1)` (expo-out) everywhere. This is the most *premium-feeling* easing curve in the toolkit — fast settle, soft landing.
4. **Duration scale:** 300ms (micro-interactions) · 600ms (UI transitions) · 900–1200ms (content reveals) · 1600ms (counters, rule draws).
5. **`prefers-reduced-motion` honored globally** — all transitions reduced to 0.01ms via the global rule.

### Specific interactions
| Element | Behavior |
|---|---|
| Header | Transparent → frosted on scroll past 24px |
| Hero headline | Mask-rise per line, 150ms stagger |
| Hero rule | Left-to-right draw (1.6s expo-out) |
| Hero mark | 8s gentle float + scroll parallax (–60px scrub) |
| Section heads | Number + title fade-rise on enter viewport |
| Service cards | Staggered fade-rise, 80ms between |
| Facts numbers | One-time count-up, 1.6s expo-out |
| Testimonials | 8s auto-advance, crossfade transition |
| Serve cards | Cream wash slides up from below on hover |
| Nav links | Hairline underline expands from center on hover |
| Buttons | Background fill on hover, arrow translates +4px |
| `link-arrow` | Gap expands from 0.5rem → 0.8rem on hover |

---

## 5. Imagery Direction

### Photography style
- **Reference aesthetic:** *Monocle* magazine portraits, *Stripe Press* editorial photography, *Brunello Cucinelli* environmental shots.
- **What to shoot:**
  - Senior trustees: black-and-white or warm-tone duotone, slightly off-axis, environmental Bay Street / boardroom context, sitter looking just-off-camera. **Never** corporate-headshot-frontal.
  - Workspace: 3–4 architectural shots of office interiors, document workflow details, hand-on-page details. *No* product photography of papers stacked or scales of justice.
- **What to avoid (from brief):**
  - ❌ Handshakes, gavels, distressed faces
  - ❌ Stock-image businesspeople
  - ❌ Generic upward-graph imagery
  - ❌ Clip-art icons
  - ❌ Anything signaling "crisis"

### Treatment
- **Portraits:** apply a subtle duotone in navy + cream when used in dark sections; full B&W with warm tone when in light sections. Treatment should be consistent across all portraits to read as a unified series.
- **Environmental shots:** keep in color but desaturate 15–20%, push warm tones slightly.

### Icons
- **Iconify with `ph:` (Phosphor) set** — light or regular weight. Used sparingly for navigation, arrows, search, social only.
- **No iconography in body content** — content is type-driven, never icon-driven.

### The AG triangle as visual motif
The AG icon (from the new V6 logo) appears as a **recurring geometric thread**:
- Hero — full-bleed 55vw at 6% opacity, parallax
- Section dividers — could optionally be embossed as a 24px mark at the start of each section number (production enhancement, mockup omits)
- Why AGI — bleeds from top-right corner with jade-fill at 18% opacity
- Footer — full logo reverse-treatment

This is the **only ornament** that recurs. It earns its presence by being the firm's mark. Any other decorative element would feel arbitrary.

---

## 6. Component Hierarchy (for Sitefinity Widget Architecture)

```
Layout (_Layout.cshtml)
├── SiteHeader.cshtml          [Sticky, transparent → frosted]
├── @RenderBody
│   ├── Hero.cshtml             [model: HeroViewModel]
│   ├── WhoWeAre.cshtml         [model: WhoWeAreViewModel + Testimonials[]]
│   ├── People.cshtml           [model: List<PersonViewModel>]
│   ├── WhoWeServe.cshtml       [model: List<AudienceCardViewModel>]
│   ├── Facts.cshtml            [model: List<FactViewModel>]
│   ├── HowWeHelp.cshtml        [model: HowWeHelpViewModel + Services[]]
│   └── WhyAGI.cshtml           [model: WhyAGIViewModel]
└── SiteFooter.cshtml           [model: FooterViewModel]
```

**Shared partials:**
- `_AGMark.cshtml` — the inline SVG triangle mark (one symbol definition)
- `_SectionHead.cshtml` — the `3/9` section header pattern (takes number + title)

Each section partial accepts a strongly-typed view model so Sitefinity editors can populate fields without touching markup.

---

## 7. Accessibility & Performance

### A11y
- Semantic HTML throughout (`<header>`, `<nav>`, `<main>`, `<section>`, `<article>`, `<footer>`, `<address>`).
- Every section has an `aria-labelledby` pointing to its heading.
- All interactive elements have `aria-label` when content is iconic.
- Color contrast: navy on cream = **17.3:1** (AAA); jade-deep on cream = **5.1:1** (AA Large); jade-deep on paper = **5.2:1** (AA Large). All large-display use of jade-deep is at body-size or larger. No body text ever uses jade.
- `prefers-reduced-motion` reduces transitions to 0.01ms globally.
- Skip-to-content link should be added in production (omitted in mockup for clarity).

### Performance
- Fonts: only Fraunces variable, Inter Tight (3 weights), JetBrains Mono (2 weights). Variable fonts mean one Fraunces request covers all weights.
- Images: `loading="lazy"` on all below-the-fold; `fetchpriority="high"` on hero hero-essential.
- Animations: GPU-composited (transform / opacity only). No layout-thrashing properties animated.
- Alpine.js: ~15KB gzipped. GSAP + ScrollTrigger: ~70KB — load `defer`. CSS-only fallback works without JS (CSS reveals via `is-visible` class added by IntersectionObserver from Alpine `x-intersect`).

### Lighthouse targets (production)
- Performance: ≥ 92
- Accessibility: ≥ 98
- Best Practices: ≥ 95
- SEO: ≥ 95

---

## 8. Outstanding Decisions for Client Sign-Off

Before development kickoff, please confirm:

1. **Hero option** — design uses *Option 1* ("Senior Judgment. Right-Sized Support."). Confirm or substitute Option 2/3.
2. **Facts 4–7** — confirm or refine the four suggested data points. "0% senior turnover" especially needs HR sign-off.
3. **People list** — confirm names, titles, and order. Photography brief separate.
4. **Testimonial quotes** — supply three real, attributable quotes (anonymized OK if from prestigious firms).
5. **Adobe Fonts upgrade** — if AGI has an Adobe Creative Cloud team subscription, we can swap Fraunces → *Freight Display Pro* and Inter Tight → *Acumin Pro* in production for an even more refined feel. Identical implementation pattern; +$0 cost if already licensed.
6. **Amber gold usage** — currently zero on the homepage (reserved for awards/recognitions). Confirm if any badges should appear above-the-fold.
7. **Insolvency Documents module** — per brief, the existing module must remain. Plan to add as a callout above the footer or as a quiet element in the header utility row.

---

## 9. Implementation Stack

| Layer | Technology | Notes |
|---|---|---|
| CMS | Sitefinity v15.4 | Existing |
| Renderer | .NET Core Renderer | ASP.NET Core MVC |
| Templates | Razor `.cshtml` | Per-section partials with view models |
| CSS | Tailwind CSS v4 | CSS-first `@theme` config; see `sitefinity/app.css` |
| JS Framework | Alpine.js v3.x | Component-scoped, no global state except Alpine store for theme |
| Animation | GSAP 3 + ScrollTrigger | Via CDN, loaded `defer` |
| Icons | Iconify (`ph:`) | On-demand from CDN |
| Fonts | Google Fonts | Optional Adobe Fonts swap |

All production code is in `/sitefinity/` directory — see that folder's README for porting steps.

---

**Document prepared by Cubicle Fugitive · v1.0 · May 2026**
