# Albert Gelman Inc. — Homepage Design Package

A complete creative-direction and front-end implementation for the
Albert Gelman Inc. (AGI) homepage redesign — built on the
Sitefinity v15.4 / .NET Core Renderer / Tailwind v4 / Alpine.js / GSAP
stack.

**Direction:** *Editorial Tension × Swiss Restraint.*
Magazine-style asymmetric grids, oversized Fraunces serif, mono eyebrows,
generous whitespace. Warmer than KSV. More polished than the competition.

---

## What's in this package

```
albert-gelman/
├── README.md                  ← you are here
├── index.html                 ← static, browser-openable preview of the full homepage
├── design-rationale.md        ← creative direction, design system, section-by-section logic
│
├── assets/                    ← brand asset masters
│   ├── AG_Icon_rgb.webp
│   ├── AG_Logo_rgb.webp
│   ├── AG_Logo_reverse_blue-rgb.webp
│   └── AG_Logo_reverse_green-rgb.webp
│
└── sitefinity/                ← production-ready Razor partials + Tailwind CSS
    ├── README.md              ← integration steps for the Sitefinity project
    ├── app.css                ← Tailwind v4 @theme inline + component CSS
    ├── _Layout.cshtml         ← master layout (fonts, scripts, AG mark, Alpine root)
    ├── _AGMark.cshtml         ← reusable SVG <symbol> partial
    ├── _SectionHead.cshtml    ← shared 3/9 section header
    ├── Header.cshtml          ← sticky site header
    ├── Hero.cshtml            ← 01
    ├── WhoWeAre.cshtml        ← 02
    ├── People.cshtml          ← 03
    ├── WhoWeServe.cshtml      ← 04
    ├── Facts.cshtml           ← 05
    ├── HowWeHelp.cshtml       ← 06
    ├── WhyAGI.cshtml          ← 07
    ├── SiteFooter.cshtml      ← footer
    ├── Index.cshtml           ← reference homepage assembly
    └── ViewModels.cs          ← all C# view models in one file
```

---

## How to review

### 1. Open the visual deliverable
Open `index.html` in any modern browser. It's a self-contained preview
using CDN-loaded Fraunces, Inter Tight, JetBrains Mono, Iconify, GSAP,
and Alpine.js — no build step needed. Resize the window to verify the
responsive breakpoints.

### 2. Read the creative direction
`design-rationale.md` documents the *why* behind every decision —
strategic premise, design system tokens, section-by-section direction,
motion philosophy, imagery direction, component hierarchy, accessibility
targets, and the seven outstanding decisions awaiting client sign-off.

### 3. Hand to engineering
`sitefinity/` contains the production code. Start with `sitefinity/README.md`
for the integration steps; the partials are designed to be Sitefinity-widget-
registered so editors retain CMS-editable control of every section.

---

## Stack at a glance

| Layer       | Tech                                                |
|-------------|-----------------------------------------------------|
| CMS         | Sitefinity v15.4                                    |
| Renderer    | .NET Core Renderer (ASP.NET Core)                   |
| Templates   | Razor `.cshtml` MVC widgets                         |
| CSS         | Tailwind v4 — CSS-first `@theme inline` config      |
| JS          | Alpine.js v3 + Intersect plugin                     |
| Motion      | GSAP 3.12 + ScrollTrigger                           |
| Icons       | Iconify (`ph:` Phosphor set)                        |
| Fonts       | Fraunces · Inter Tight · JetBrains Mono             |

---

## Design system tokens (summary)

```
ink           oklch(18% 0.05 264)      deep navy — primary
jade          oklch(56% 0.16 148)      brand green — accent
jade-deep     oklch(46% 0.15 148)      italic accents, hovers
amber         oklch(82% 0.16 88)       reserved for awards <2% usage
paper         oklch(98.5% 0.004 80)    warm off-white default
cream         oklch(96.5% 0.016 82)    Hero / Who We Serve cards
mint          oklch(96% 0.022 152)     Facts section
ash           oklch(88% 0.006 240)     hairline rules
```

60 / 30 / 10 — paper-cream / navy / jade. Amber lives in awards only.

---

## Outstanding decisions for client sign-off

1. Confirm hero headline — **"Senior Judgment. Right-Sized Support."**
2. Confirm/refine Facts #4–7 (especially "0% senior turnover" — needs HR sign-off)
3. Supply 3 real testimonial quotes (currently anonymised placeholders)
4. Confirm People list (currently 6, with 4 illustrative placeholders)
5. Adobe Fonts upgrade preference (Freight Display Pro + Acumin Pro vs current Google stack)
6. Amber gold usage above-the-fold (currently zero — reserved for awards)
7. Placement of Insolvency Documents module (must remain per brief)
