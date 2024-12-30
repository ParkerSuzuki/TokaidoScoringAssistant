using System;

public class TokaidoScorer
{
    /// <summary>
    /// Enumeration representing the types of panoramas.
    /// </summary>
    public enum PanoramaType
    {
        Paddy
		Mountain,
		Sea
	}

    /// <summary>
    /// Enumeration representing the types of souvenirs.
    /// </summary>
    public enum SouvenirType
    {
        SmallObject,
        Clothing,
        Art,
        Food
	}

    /// <summary>
    /// Enumeration representing the types of achievements.
    /// </summary>
    public enum AchievementType
    {
        FirstPaddyPanorama,
        FirstMountainPanorama,
        FirstSeaPanorama,
        MostHotSprings,
        MostSouvenirs,
        MostEncounters,
        HigestMealCost
    }

    /// <summary>
    /// Enumeration representing special traveler types.
    /// </summary>
    public enum SpecialTravelerType
    {
        None,
        Mitsukuni,
        Umegae
    }

    private int paddySectionCount = 0;
    private int mountainSectionCount = 0;
    private int seaSectionCount = 0;

    private int smallObjectSouvenirCount = 0;
    private int clothingSouvenirCount = 0;
    private int artSouvenirCount = 0;
    private int foodSouvenirCount = 0;

    private int hotSpring2Count = 0;
    private int hotSpring3Count = 0;

    private int templeCoinCount = 0;
    private int templeRank = 0;

    private int samuraiEncounterCount = 0;
    private int nonSamuraiEncounterCount = 0;
    
    private int mealCount = 0;

    private bool firstPaddyPanorama = false;
    private bool firstMountainPanorama = false;
    private bool firstSeaPanorama = false;
    private bool mostHotSprings = false;
    private bool mostSouvenirs = false;
    private bool mostEncounters = false;
    private bool highestMealCost = false;

    private SpecialTravelerType travelerType = SpecialTravelerType.None;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokaidoScorer"/> class.
    /// </summary>
    public TokaidoScorer()
    {
    }

    /// <summary>
    /// Sets the number of sections completed for a specified panorama type.
    /// </summary>
    /// <param name="panorama">The type of panorama to update.</param>
    /// <param name="sectionCount">The number of sections completed.</param>
    /// <exception cref="ArgumentException">Thrown if input is invalid.</exception>
    public void setPanoramaCount(PanoramaType panorama, int sectionCount)
    {
        // Validate input
        if (sectionCount < 0)
        {
            throw new ArgumentException("Invalid section count used.");
        }

        // Update the section count based on panorama type
        switch (panorama)
        {
            case PanoramaType.Paddy:
                paddySectionCount = Math.Min(sectionCount, 3);
                break;
            case PanoramaType.Mountain:
                mountainSectionCount = Math.Min(sectionCount, 4);
                break;
            case PanoramaType.Sea:
                seaSectionCount = Math.Min(sectionCount, 5);
                break;
            default:
                throw new ArgumentException("Invalid panorama type used");
        }
    }

    /// <summary>
    /// Gets the number of sections completed for a specified panorama type.
    /// </summary>
    /// <param name="panorama">The type of panorama to retrieve.</param>
    /// <returns>The number of sections completed.</returns>
    /// <exception cref="ArgumentException">Thrown if input is invalid.</exception>
    public int getPanorama(PanoramaType panorama)
    {
        switch (panorama)
        {
            case PanoramaType.Paddy:
                return paddySectionCount;
            case PanoramaType.Mountain:
                return mountainSectionCount;
            case PanoramaType.Sea:
                return seaSectionCount;
            default:
                throw new ArgumentException("Invalid panorama type used");
        }
    }

    /// <summary>
    /// Calculates and returns the total score for all panoramas.
    /// </summary>
    /// <returns>The total panorama score.</returns>
    public int getTotalPanoramaScore()
    {
        int totalPanoramaScore = 0;
        for (int i = paddySectionCount; i > 0; i--)
        {
            totalPanoramaScore += i;
        }

        for (int i = mountainSectionCount; i > 0; i--)
        {
            totalPanoramaScore += i;
        }

        for (int i = seaSectionCount; i > 0; i--)
        {
            totalPanoramaScore += i;
        }

        return totalPanoramaScore;
    }

    /// <summary>
    /// Sets the number of souvenirs collected for a specific type.
    /// </summary>
    /// <param name="souvenir">The type of souvenir.</param>
    /// <param name="souvenirCount">The number of souvenirs collected.</param>
    /// <exception cref="ArgumentException">Thrown if input is invalid.</exception>
    public int setSouvenirCount(SouvenirType souvenir, int souvenirCount) 
    {
        // Validate input
        if (souvenirCount < 0)
        {
            throw new ArgumentException("Invalid souvenir count used.");
        }

        // Update the souvenir count based on souvenir type
        switch (souvenir)
        {
            case SouvenirType.SmallObject:
                smallObjectSouvenirCount = souvenirCount;
                break;
            case SouvenirType.Clothing:
                clothingSouvenirCount = souvenirCount;
                break;
            case SouvenirType.Art:
                artSouvenirCount = souvenirCount;
                break;
            case SouvenirType.Food:
                foodSouvenirCount = souvenirCount;
                break
            default:
                throw new ArgumentException("Invalid souvenir type used");
        }
    }

    /// <summary>
    /// Retrieves the count of a specific type of souvenir collected.
    /// </summary>
    /// <param name="souvenir">The type of souvenir.</param>
    /// <returns>The count of the specified souvenir type.</returns>
    /// <exception cref="ArgumentException">Thrown if an invalid souvenir type is provided.</exception>
    public int getSouvenirCount(SouvenirType souvenir)
    {
        switch (souvenir)
        {
            case SouvenirType.SmallObject: return smallObjectSouvenirCount;
            case SouvenirType.Clothing: return clothingSouvenirCount;
            case SouvenirType.Art: return artSouvenirCount;
            case SouvenirType.Food: return foodSouvenirCount;
            default: throw new ArgumentException("Invalid souvenir type used");
        }
    }

    /// <summary>
    /// Calculates and returns the total score based on collected souvenir sets.
    /// </summary>
    /// <returns>The total score calculated based on souvenir sets.</returns>
	public int getTotalSouvenirScore()
    {
        int[] souvenirCounts = { smallObjectSouvenirCount, clothingSouvenirCount, artSouvenirCount, foodSouvenirCount };
        Array.Sort(souvenirCounts);
        Array.Reverse(souvenirCounts);

        int totalScore = 0;
        for (int i = 0; i < souvenirCounts[0]; i++) totalScore += 1;
        for (int i = 0; i < souvenirCounts[1]; i++) totalScore += 3;
        for (int i = 0; i < souvenirCounts[2]; i++) totalScore += 5;
        for (int i = 0; i < souvenirCounts[3]; i++) totalScore += 7;

        return totalScore;
    }

    /// <summary>
    /// Sets the count of hot springs visited with a specified point value.
    /// </summary>
    /// <param name="pointValue">The point value of the hot springs (2 or 3).</param>
    /// <param name="hotSpringCount">The number of hot springs visited.</param>
    /// <exception cref="ArgumentException">Thrown if pointValue is invalid.</exception>
    public void setHotSpringCount(int pointValue, int hotSpringCount)
    {
        if (pointValue == 2) hotSpring2Count = hotSpringCount;
        else if (pointValue == 3) hotSpring3Count = hotSpringCount;
        else throw new ArgumentException("Invalid pointValue used");
    }

    /// <summary>
    /// Gets the count of hot springs visited with a specified point value.
    /// </summary>
    /// <param name="pointValue">The point value of the hot springs (2 or 3).</param>
    /// <returns>The count of hot springs visited.</returns>
    /// <exception cref="ArgumentException">Thrown if pointValue is invalid.</exception>
    public int getHotSpringCount(int pointValue) 
    {
        if (pointValue == 2) return hotSpring2Count;
        else if (pointValue == 3) return hotSpring3Count;
        else throw new ArgumentException("Invalid pointValue used");
    }

    /// <summary>
    /// Calculates and returns the total score based on visited hot springs.
    /// </summary>
    /// <returns>The total score from hot springs based on the traveler's type.</returns>
    public int getTotalHotSpringScore()
    {
        if (travelerType == SpecialTravelerType.Mitsukuni)
        {
            return 3 * hotSpring2Count + 4 * hotSpring3Count;
        }
        else
        {
            return 2 * hotSpring2Count + 3 * hotSpring3Count;
        }
    }

    /// <summary>
    /// Sets the number of coins donated to the temple.
    /// </summary>
    /// <param name="coinCount">The number of coins donated.</param>
    public void setTempleCoinCount(int coinCount)
    {
        templeCoinCount = coinCount;
    }

    /// <summary>
    /// Sets the rank achieved at the temple.
    /// </summary>
    /// <param name="rank">The rank achieved (1-5).</param>
    public void setTempleRank(int rank)
    {
        templeRank = rank;
    }

    /// <summary>
    /// Gets the number of coins donated to the temple.
    /// </summary>
    /// <returns>The number of coins donated.</returns>
    public int getTempleCoinCount() 
    { 
        return templeCoinCount;
    }

    /// <summary>
    /// Gets the rank achieved at the temple.
    /// </summary>
    /// <returns>The rank achieved (1-5).</returns>
    public int getTempleRank()
    {
        return templeRank;
    }

    /// <summary>
    /// Calculates and returns the total temple score based on coins and rank.
    /// </summary>
    /// <returns>The total score including temple rank bonus.</returns>
    public int getTotalTempleScore()
    {
        int templeRankPoints = 0;
        switch (templeRank)
        {
            case 1:
                templeRankPoints = 10;
                break;
            case 2: 
                templeRankPoints = 7; 
                break;
            case 3:
                templeRankPoints = 4;
                break;
            case 4:
                templeRankPoints = 2;
                break;
            case 5:
                templeRankPoints = 2;
                break;
            default:
                templeRankPoints = 0;
        }

        return templeCoinCount + templeRankPoints;
    }

    /// <summary>
    /// Sets the count of samurai encounters.
    /// </summary>
    /// <param name="samuraiCount">The number of samurai encounters.</param>
    public void setSamuraiEncounterCount(int samuraiCount)
    {
        samuraiEncounterCount = samuraiCount;
    }

    /// <summary>
    /// Sets the count of non-samurai encounters.
    /// </summary>
    /// <param name="nonSamuraiCount">The number of non-samurai encounters.</param>
    public void setNonSamuraiEncounterCount(int nonSamuraiCount)
    {
        nonSamuraiEncounterCount = nonSamuraiCount;
    }

    /// <summary>
    /// Gets the count of samurai encounters.
    /// </summary>
    /// <returns>The number of samurai encounters.</returns>
    public int getSamuraiEncounterCount()
    {
        return samuraiEncounterCount;
    }

    /// <summary>
    /// Gets the count of non-samurai encounters.
    /// </summary>
    /// <returns>The number of non-samurai encounters.</returns>
    public int getNonSamuraiEncounterCount()
    {
        return nonSamuraiEncounterCount;
    }

    /// <summary>
    /// Calculates and returns the total score based on encounters.
    /// </summary>
    /// <returns>The total score based on encounters and traveler type.</returns>
    public int getTotalEncounterScore()
    {
        if (travelerType == SpecialTravelerType.Umegae)
        {
            return nonSamuraiEncounterCount + samuraiEncounterCount * 4;
        }
        else
        {
            return samuraiEncounterCount * 3;
        }
    }

    /// <summary>
    /// Sets the number of meals purchased.
    /// </summary>
    /// <param name="mealCount">The number of meals purchased.</param>
    public void setMealCount(int mealCount)
    {
        this.mealCount = mealCount;
    }

    /// <summary>
    /// Gets the number of meals purchased.
    /// </summary>
    /// <returns>The number of meals purchased.</returns>
    public int getMealCount()
    {
        return mealCount;
    }

    /// <summary>
    /// Calculates and returns the total score based on purchased meals.
    /// </summary>
    /// <returns>The total meal score, calculated as 6 points per meal.</returns>
    public int getTotalMealScore()
    {
        return mealCount * 6;
    }

    /// <summary>
    /// Sets whether a specific achievement has been earned.
    /// </summary>
    /// <param name="achievement">The type of achievement.</param>
    /// <param name="playerHas">True if the player earned the achievement; otherwise, false.</param>
    /// <exception cref="ArgumentException">Thrown if an invalid achievement type is provided.</exception>
    public void setAchievement(AchievementType achievement, bool playerHas) 
    { 
        switch (achievement) 
        {
            case AchievementType.FirstPaddyPanorama:
                firstMountainPanorama = playerHas; 
                break;
            case AchievementType.FirstMountainPanorama:
                firstMountainPanorama = playerHas;
                break;
            case AchievementType.FirstSeaPanorama:
                firstSeaPanorama = playerHas;
                break;
            case AchievementType.MostHotSprings:
                mostHotSprings = playerHas;
                break;
            case AchievementType.MostSouvenirs:
                mostSouvenirs = playerHas;
                break;
            case AchievementType.MostEncounters:
                mostEncounters = playerHas;
                break;
            case AchievementType.HigestMealCost:
                highestMealCost = playerHas;
                break;
            default:
                throw new ArgumentException("Invalid AchievementType used");
        }
    }

    /// <summary>
    /// Gets whether a specific achievement has been earned.
    /// </summary>
    /// <param name="achievement">The type of achievement.</param>
    /// <returns>True if the achievement was earned; otherwise, false.</returns>
    /// <exception cref="ArgumentException">Thrown if an invalid achievement type is provided.</exception>
    public bool getAchievement(AchievementType achievement)
    {
        switch (achievement)
        {
            case AchievementType.FirstPaddyPanorama:
                return firstMountainPanorama;
            case AchievementType.FirstMountainPanorama:
                return firstMountainPanorama;
            case AchievementType.FirstSeaPanorama:
                return firstSeaPanorama;
            case AchievementType.MostHotSprings:
                return mostHotSprings;
            case AchievementType.MostSouvenirs:
                return mostSouvenirs;
            case AchievementType.MostEncounters:
                return mostEncounters;
            case AchievementType.HigestMealCost:
                return highestMealCost;
            default:
                throw new ArgumentException("Invalid AchievementType used");
        }
    }

    /// <summary>
    /// Calculates and returns the total score from achievements.
    /// </summary>
    /// <returns>The total achievement score based on achievements earned and traveler type.</returns>
    public int getTotalAchievementScore()
    {
        int achievementCount = 0;
        if (firstPaddyPanorama) achievementCount++;
        if (firstMountainPanorama) achievementCount++;
        if (firstSeaPanorama) achievementCount++;
        if (mostHotSprings) achievementCount++;
        if (mostSouvenirs) achievementCount++;
        if (mostEncounters) achievementCount++;
        if (highestMealCost) achievementCount++;

        if (travelerType == SpecialTravelerType.Mitsukuni)
        {
            return achievementCount * 4;
        }
        else
        {
            return achievementCount * 3;
        }
    }

    /// <summary>
    /// Sets the type of special traveler for the player.
    /// </summary>
    /// <param name="travelerType">The special traveler type.</param>
    public void setTravelerType(SpecialTravelerType travelerType)
    {
        this.travelerType = travelerType;
    }

    /// <summary>
    /// Gets the type of special traveler for the player.
    /// </summary>
    /// <returns>The special traveler type.</returns>
    public SpecialTravelerType getTravelerType()
    {
        return travelerType;
    }

    /// <summary>
    /// Calculates and returns the total score from all scoring categories.
    /// </summary>
    /// <returns>The total score combining panoramas, hot springs, achievements, encounters, meals, souvenirs, and temple points.</returns>
    public int getTotalScore()
    {
        return getTotalPanoramaScore() + getTotalHotSpringScore() + getTotalAchievementScore() + getTotalEncounterScore() + getTotalMealScore() + getTotalSouvenirScore() + getTotalTempleScore();
    }
}
